using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCar : Enemy
{

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new RcCarIdle(this,stateMachine,"Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new RcCarMove(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new RcCarAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Skill, new RcCarSkill(this, stateMachine, "Skill"));
        stateMachine.AddState(EnemyStatEnum.Dead, new RcCarDie(this, stateMachine, "Die"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
    }
}
