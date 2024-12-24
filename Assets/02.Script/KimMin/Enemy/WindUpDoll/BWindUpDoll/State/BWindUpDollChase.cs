using Ami.BroAudio;
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
        BroAudio.Play(_windUpDoll.WindUp);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _currrentTime += Time.deltaTime;

        if (_currrentTime >= 3f)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
    }

    public override void Exit()
    {
        base.Exit();
        BroAudio.Pause(_windUpDoll.WindUp);
    }
}