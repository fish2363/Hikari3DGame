using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody RigidCompo { get; private set; }
    [field: SerializeField] public CharacterController ControllerCompo { get; private set; }

    public float MaxHp { get { return maxHp; } }
    public float CurrentHp { get { return currentHp; } }
    public float MoveSpeed { get { return moveSpeed; } }

    [field : SerializeField]
    public GroundCheck GroundCheck { get; private set; }

    [SerializeField]
    protected float maxHp;
    [SerializeField]
    protected float currentHp;
    [SerializeField]
    protected float moveSpeed, gravity = -9.8f;

    public CharacterController CControllerCompo { get; private set; }
    public bool IsRunning { get; private set; }


    [field : SerializeField] public Animator animator { get; private set; }

    [SerializeField] private float _dashCoolTime;
    private float _lastDashTime;


    private Dictionary<StateEnum, State> stateDictionary = new Dictionary<StateEnum, State>();
    private StateEnum currentEnum;

    private void Awake()
    {
        foreach(StateEnum enumState in Enum.GetValues(typeof(StateEnum)))
        {
            Type t = Type.GetType($"{enumState}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            stateDictionary.Add(enumState,state);
        }
        ChangeState(StateEnum.Idle);

        InputReader.OnDashEvent += HandleDashEvent;
        InputReader.OnJumpEvent += HandleJumpEvent;
    }

    private void Update()
    {
        stateDictionary[currentEnum].StateUpdate();
    }

    private void FixedUpdate()
    {
        stateDictionary[currentEnum].StateFixedUpdate();
    }

    private void HandleJumpEvent()
    {

    }

    private void HandleDashEvent()
    {
        if (AttemptDash())
        {
            ChangeState(StateEnum.Dash);
        }
    }

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
        currentHp -= attackDamage;
    }

    public void PlusHp(float Heal)
    {
        currentHp += Heal;
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

}
