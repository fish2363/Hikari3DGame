using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BWindUpDollChase : EnemyState<EnemyStatEnum>
{
    private BWindUpDoll _windUpDoll;
    private float _currrentTime;

    public BWindUpDollChase(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as BWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        _currrentTime = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _currrentTime += Time.deltaTime;

        if (_currrentTime >= _windUpDoll.explostionTime)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
    }
}