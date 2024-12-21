using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBass : Entity
{
    public bool IsPhaseEnd;
    public bool WallChecker = false;

    [SerializeField] private EntityFSMSO _bossFSM;

    [SerializeField] protected StateMachine _stateMachine;

    [field : SerializeField] public EnemyStatSO EnemyStat;

    public Vector3 targetDir;

    public Rigidbody RigidCompo;

    public EntityState CurrentState => _stateMachine.currentState;

    public Player player;

    protected override void Awake()
    {
        base.Awake();
        RigidCompo = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    protected override void AfterInitialize()
    {
        base.AfterInitialize();
        _stateMachine = new StateMachine(_bossFSM, this);
    }

    public void ChangeState(BossState newState)
    {
        _stateMachine.ChageState(newState);
    }

    protected virtual void Update()
    {
        _stateMachine.currentState.UpdateState();
    }

    public EntityState GetState(StateSO state)
    {
        return _stateMachine.GetState(state.stateName);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallChecker = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        WallChecker = false;
    }
}
