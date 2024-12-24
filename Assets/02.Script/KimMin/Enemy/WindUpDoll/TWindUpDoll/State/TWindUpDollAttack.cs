using Ami.BroAudio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;
    private float _currentTime;

    public TWindUpDollAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        _windUpDoll.isCollision = true;
        _windUpDoll.canAttack = false;
        _currentTime = 0;

        BroAudio.Play(_windUpDoll.WindUp);
        _windUpDoll.StartCoroutine(AttackRoutine());
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _currentTime += Time.deltaTime;
        if (_currentTime > 1f)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }

    public override void Exit()
    {
        base.Exit();
        BroAudio.Pause(_windUpDoll.WindUp);
    }

    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(_windUpDoll.EnemyStat.AttackDelay);
        _windUpDoll.canAttack = true;
    }
}