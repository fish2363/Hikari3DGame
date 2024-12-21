using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody RigidCompo { get; private set; }
    [field: SerializeField] public Transform virtualCamera { get; private set; }

    public bool isStop { get; set; }
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


    [field: SerializeField] public WeaponData currentWeaponData;
    [field: SerializeField] public Animator animator { get; private set; }

    [SerializeField] private float _dashCoolTime;
    [SerializeField] private float _attckCoolTime;
    private float _lastDashTime;

    public LayerMask whatIsEnemy;


    private Dictionary<StateEnum, State> stateDictionary = new Dictionary<StateEnum, State>();
    private StateEnum currentEnum;

    public ShowEffect attackEffect;

    private void Awake()
    {
        foreach (StateEnum enumState in Enum.GetValues(typeof(StateEnum)))
        {
            Type t = Type.GetType($"{enumState}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            stateDictionary.Add(enumState, state);
        }
        ChangeState(StateEnum.Idle);

        InputReader.OnDashEvent += HandleDashEvent;
        InputReader.OnJumpEvent += HandleJumpEvent;
        InputReader.AttackEvent += HandleAttackEvent;
        InputReader.OnSheldEvent += HandleBlaockEvent;

        isAttack = true;
        isBlock = true;

        maxHp = currentHp.Value;
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
                print("Mainmenu부터 실행하지 않으면 ESC 안됨미다");
            }
            print(currentHp);
            stateDictionary[currentEnum].StateUpdate();
        }
        Mathf.Clamp(freelook.m_YAxis.Value, 0.4f, 1f);
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
            if (isBlock)
            {
                ChangeState(StateEnum.Sheld);
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

    public void MinusHp(float attackDamage)
    {
        if (!isStop)
        {
            if (!isBlock)
                currentHp.Value -= attackDamage / 2;
            else if (isBlock)
            {
                currentHp.Value -= attackDamage;
            }
        }
    }

    public void PlusHp(float Heal)
    {
        currentHp.Value += Heal;
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
        Gizmos.color = Color.white;
    }
}
