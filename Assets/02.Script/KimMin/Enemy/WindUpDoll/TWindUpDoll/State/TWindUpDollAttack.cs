using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;
    private float _time;

    public TWindUpDollAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Attack");
        _time = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _time += Time.deltaTime;

        if (_time > 1)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }
}