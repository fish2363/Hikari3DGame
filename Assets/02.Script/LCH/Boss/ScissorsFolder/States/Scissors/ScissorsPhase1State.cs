using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase1State : EnemyState<BossState>
{
    private Scissors _scissors;
    private bool _isAttackWait = true;
    public ScissorsPhase1State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
    }

    public override void Enter()
    {
        base.Enter();
        _scissors.StartCoroutine(AttackWaitCoroutine());
    }

    private IEnumerator AttackWaitCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _isAttackWait = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_isAttackWait)
        {
            _scissors.RigidCompo.AddForce(new Vector3(_scissors.player.transform.position.x,_scissors.player.transform.position.y
                ,_scissors.player.transform.position.z).normalized);
        }
    }
}
