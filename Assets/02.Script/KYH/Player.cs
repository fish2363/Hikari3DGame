using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IDamageable
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody RigidCompo { get; private set; }
    [field: SerializeField] public Transform virtualCamera { get; private set; }

    public bool isShield { get; set; }
    public bool isStop { get; set; }

    public bool _isSkill { get; set; }

    public bool _isSkillCoolTime { get; set; }

    public float MaxHp { get { return maxHp; } }
  //  public float CurrentHp { get { return currentHp; } }
    public float MoveSpeed { get { return moveSpeed; }  }
    public CinemachineFreeLook freelook;

    [field: SerializeField]
    public GroundCheck GroundCheck { get; private set; }

    [field: SerializeField]
    public Transform RayTransform { get; private set; }

    [field: SerializeField] public GameObject playerCam { get; set; }


    [SerializeField]
    protected float maxHp;

    [field : SerializeField]
    public NotifyValue<float> currentHp { get; set; } = new NotifyValue<float>();

    [SerializeField]
    protected float moveSpeed, gravity = -9.8f;

    public CharacterController CControllerCompo { get; private set; }
    public bool IsRunning { get; private set; }
    public bool isAttack { get; set; }
    public bool isBlock { get; set; }

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

        isAttack = true;
        isBlock = true;

        maxHp = currentHp.Value;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _isSkillCoolTime = true;
        _isSkill = true;
    }


    private void Update()
    {
        if(!isStop)
        {
            try
            {
                freelook.m_XAxis.m_MaxSpeed = SettingManager.Instance.Sensitivity * 100;
            }
            catch (Exception e)
            {
                print("Mainmenu���� �������� ������ ESC �ȵʹ̴�");
            }
            print(currentHp);
            stateDictionary[currentEnum].StateUpdate();
        }
        scroll = -(Input.GetAxis("Mouse ScrollWheel") * 10);
        freelook.m_YAxis.Value=Mathf.Clamp(freelook.m_YAxis.Value, 0.4f, 1f);
        freelook.m_Orbits[1].m_Radius = Mathf.Clamp(freelook.m_Orbits[1].m_Radius+=scroll, 2f, 12f);

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
        if(currentWeaponData.weaponName == "Pencil")
        {
            if (isShield)
            {
                ChangeState(StateEnum.Sheld);
            }
        }
    }

    private void HandleSkillEvent()
    {
        if(currentWeaponData.weaponName == "Spon" || currentWeaponData.weaponName == "Pencil")
        {
            if(_isSkillCoolTime)
            {
                ChangeState(StateEnum.Skill);
            }
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

    private bool AttemptDash()
    {
        if (currentEnum == StateEnum.Dash) return false;

        if (_lastDashTime + _dashCoolTime > Time.time) return false;

        _lastDashTime = Time.time;
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
            if (!isBlock)
                currentHp.Value -= damage / 2;
            else if (isBlock)
            {
                currentHp.Value -= damage;
            }
        }
    }

    public void PlusHp(float Heal)
    {
        currentHp.Value += Heal;
    }

    public void Die()
    {
        if(currentHp.Value <= 0)
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



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(RayTransform.position, size);
      
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(RayTransform.position, SkillSize);
        Gizmos.color = Color.white;
    }


}
