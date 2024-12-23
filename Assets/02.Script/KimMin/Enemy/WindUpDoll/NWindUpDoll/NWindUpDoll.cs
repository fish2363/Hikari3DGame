using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDoll : WindUpDoll
{
    public float detectRadius = 4.0f;
    public bool canAttack = true;
    private EntityHealth _healthCompo;

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new NWindUpDollIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new NWindUpDollMove(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new NWindUpDollAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Dead, new NWindUpDollDead(this, stateMachine, "Dead"));

        _healthCompo = GetComponent<EntityHealth>();
        _healthCompo.MaxHealth = EnemyStat.HP;

        _healthCompo.OnDeath += HandleOnDeath;
    }

    private void Start()
    {
        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.CurrentState.UpdateState();
    }

    private void HandleOnDeath()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, EnemyStat.AttackRadius);
    }
}
