using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new SpiderIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new SpiderMove(this, stateMachine, "Move"));
        stateMachine.AddState(EnemyStatEnum.Chase, new SpiderChase(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyStatEnum.Attack, new SpiderAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Skill, new SpiderSkill(this, stateMachine, "Skill"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
    }

    private void Update()
    {
        Debug.Log(stateMachine.CurrentState);
        stateMachine.CurrentState.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, EnemyStat.AttackRadius);
    }
}
