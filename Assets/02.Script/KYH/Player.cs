using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IDamageable
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody RigidCompo { get; private set; }
    [field: SerializeField] public Transform virtualCamera { get; private set; }

    public bool isFullSheld { get; set; }
    public bool isShield { get; set; }
    public bool isStop { get; set; }

    public bool _isSkill { get; set; }

    public bool _isSkillCoolTime { get; set; }

    public float MaxHp { get { return maxHp; } }
    //  public float CurrentHp { get { return currentHp; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public CinemachineFreeLook freelook;
    public CinemachineFreeLook combatCamera;
    private CinemachineFreeLook currentCamera;

    [field: SerializeField]
    public GroundCheck GroundCheck { get; private set; }

    [field: SerializeField]
    public Transform RayTransform { get; private set; }

    [field: SerializeField] public GameObject playerCam { get; set; }


    [SerializeField]
    protected float maxHp;

    [field: SerializeField]
    public NotifyValue<float> currentHp { get; set; } = new NotifyValue<float>();

    [SerializeField]
    protected float moveSpeed, gravity = -9.8f;

    public bool IsRunning { get; private set; }
    public bool isAttack { get; set; }
    public bool isBlock { get; set; }
    public bool isDash { get; set; }

    public Vector3 size;

    [field: SerializeField] public Vector3 SkillSize { get; set; }


    [field: SerializeField] public WeaponData currentWeaponData;
    [field: SerializeField] public Animator animator { get; private set; }

    [SerializeField] private float _dashCoolTime;
    [SerializeField] private float _attckCoolTime;
    private float _lastDashTime;

    public LayerMask whatIsEnemy;


    private Dictionary<StateEnum, State> stateDictionary = new Dictionary<StateEnum, State>();
    private StateEnum currentEnum;

    public ShowEffect attackEffect;

    float scroll;

    public CinemachineVirtualCamera leftCamera;
    public CinemachineVirtualCamera rightCamera;
    public bool isCameraOn;
    public Vector3 velocity { get; set; }
    [Header("대쉬")]
    public float dashPower = 10f;
    public float dashCoolTime = 5f;
    [Header("대쉬 유지")]
    public float dashTime = 0.4f;

    public Volume dashVolume;




    private void Awake()
    {


        isShield = true;
        foreach (StateEnum enumState in Enum.GetValues(typeof(StateEnum)))
        {
            Type t = Type.GetType($"{enumState}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            stateDictionary.Add(enumState, state);
        }
        ChangeState(StateEnum.Idle);

        InputReader.OnSkillEvent += HandleSkillEvent;
        InputReader.OnDashEvent += HandleDashEvent;
        InputReader.OnJumpEvent += HandleJumpEvent;
        InputReader.AttackEvent += HandleAttackEvent;
        InputReader.OnSheldEvent += HandleBlaockEvent;
        InputReader.OnZoomEvent += HandleZoomEvent;

        isAttack = true;
        isBlock = true;

        maxHp = currentHp.Value;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _isSkillCoolTime = true;
        _isSkill = true;
        currentCamera = freelook;
        isFullSheld = false;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void HandleZoomEvent()
    {
        isCameraOn = !isCameraOn;

        currentCamera.Priority = 0;
        if (isCameraOn) currentCamera = combatCamera;
        else currentCamera = freelook;
        currentCamera.Priority = 10;

        //if (isCameraOn)
        //{
        //    freelook.Priority = 0;
        //    combatCamera.Priority = 10;
        //    //if (!SettingManager.Instance.LRInversion)
        //    //{
        //    //    print("왼");
        //    //    leftCamera.Priority = 11;
        //    //}
        //    //else
        //    //{
        //    //    print("오");
        //    //    rightCamera.Priority = 11;
        //    //}
        //}
        //else
        //{
        //    freelook.Priority = 10;
        //    combatCamera.Priority = 0;
        //    //if (!SettingManager.Instance.LRInversion)
        //    //{
        //    //    print("왼");
        //    //    leftCamera.Priority = 0;
        //    //}
        //    //else
        //    //{
        //    //    print("오");
        //    //    rightCamera.Priority = 0;

        //    //}
        //}
    }

    private void Update()
    {
        try
        {
            currentCamera.m_XAxis.m_MaxSpeed = SettingManager.Instance.Sensitivity * 100;
            //currentCamera.m_YAxis.m_MaxSpeed = SettingManager.Instance.Sensitivity;
        }
        catch (Exception e)
        {
            print("Mainmenu부터 실행하지 않으면 ESC 안됨미다");
        }
        print(currentHp);
        stateDictionary[currentEnum].StateUpdate();
        scroll = -(Input.GetAxis("Mouse ScrollWheel") * 10);
        //freelook.m_YAxis.Value=Mathf.Clamp(freelook.m_YAxis.Value, 0.4f, 1f);
        if (!isCameraOn)
            freelook.m_Orbits[1].m_Radius = Mathf.Clamp(freelook.m_Orbits[1].m_Radius += scroll, 2f, 12f);
        else
            combatCamera.m_Orbits[2].m_Radius = Mathf.Clamp(freelook.m_Orbits[2].m_Radius += scroll, 2f, 12f);

        Die();
    }

    private void FixedUpdate()
    {
        stateDictionary[currentEnum].StateFixedUpdate();
    }

    private void HandleAttackEvent()
    {
        if (!isStop)
        {
            if (isAttack)
            {
                ChangeState(StateEnum.Attack);
            }
        }
    }

    private void HandleBlaockEvent()
    {
        if (currentWeaponData.weaponName == "Pencil")
        {
            if (isShield)
            {
                ChangeState(StateEnum.Sheld);
            }
        }
    }

    private void HandleSkillEvent()
    {
        if (currentWeaponData.weaponName == "Spon" || currentWeaponData.weaponName == "Pencil")
        {
            if (_isSkillCoolTime)
            {
                ChangeState(StateEnum.Skill);
            }
        }
    }
    private void Dash(bool on)
    {
        LensDistortion lens;
        float startVignette;
        float endVignette;
        if (on)
        {
            startVignette = 0f;
            endVignette = -0.8f;
        }
        else
        {
            startVignette = -0.8f;
            endVignette = 0f;
        }



        if (dashVolume.profile.TryGet(out lens))
        {
            DOTween.KillAll();
            DOTween.To(() => startVignette, vloom => lens.intensity.value = vloom, endVignette, 0.2f);
        }
    }

    private void HandleJumpEvent()
    {

    }

    private void HandleDashEvent()
    {
        if (!isStop)
        {
            if (AttemptDash())
            {
                ChangeState(StateEnum.Dash);
            }
        }
    }

    /*private bool AttemptAttaack()
    {
        if (currentEnum == StateEnum.Attack) return false;

        if (_lastAttackTime + _attckCoolTime > Time.time) return false;

        _lastAttackTime = Time.deltaTime;

        return true;

    }*/

    public void DashCool()
    {
        StartCoroutine(DashCoroutine());
    }
    private IEnumerator DashCoroutine()
    {
        float currentTime = 0f;
        Dash(true);
        while (true)
        {
            RigidCompo.velocity = velocity * dashPower;
            currentTime += Time.deltaTime;
            if (currentTime >= dashTime)
            {
                Dash(false);
                RigidCompo.velocity = Vector3.zero;
                break;
            }
        }
        ChangeState(StateEnum.Idle);
        isBlock = false;

        yield return new WaitForSeconds(dashCoolTime);
        isDash = false;
    }

    private bool AttemptDash()
    {
        if (currentEnum == StateEnum.Dash || isDash) return false;

        //if (_lastDashTime + _dashCoolTime > Time.time) return false;

        //_lastDashTime = Time.time;
        return true;
    }

    public void ChangeState(StateEnum newEnum)
    {
        stateDictionary[currentEnum].Exit();
        currentEnum = newEnum;
        stateDictionary[currentEnum].Enter();
    }

    public void ApplyDamage(float damage)
    {
        if (!isStop)
        {
            if (isFullSheld)
                return;
            else if (isBlock)
            {
                currentHp.Value -= damage;
            }
            else if(!isShield)
            {
                currentHp.Value -= damage / 2;
            }
        }
    }

    public void PlusHp(float Heal)
    {
        currentHp.Value += Heal;
    }

    public void Die()
    {
        if (currentHp.Value <= 0)
        {
            ChangeState(StateEnum.Die);
        }
    }

    public void MinusMoveSpeed(float MinusSpeed)
    {
        moveSpeed -= MinusSpeed;

        StartCoroutine(ReturnMoveSpeed());
    }

    public void PlusMoveSpeed(float PlusSpeed)
    {
        moveSpeed -= PlusSpeed;
    }

    private IEnumerator ReturnMoveSpeed()
    {
        yield return new WaitForSeconds(3f);

        moveSpeed = 300;
    }

    public void ShowAttackEffect()
    {
        var attacEffect = Instantiate(attackEffect);
        attacEffect.SetPositionAndPlay(transform.position, transform);
    }

    private void OnDisable()
    {
        InputReader.OnSkillEvent -= HandleSkillEvent;
        InputReader.OnDashEvent -= HandleDashEvent;
        InputReader.OnJumpEvent -= HandleJumpEvent;
        InputReader.AttackEvent -= HandleAttackEvent;
        InputReader.OnSheldEvent -= HandleBlaockEvent;
        InputReader.OnZoomEvent -= HandleZoomEvent;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(RayTransform.position, size);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(RayTransform.position, SkillSize);
        Gizmos.color = Color.white;
    }


}
