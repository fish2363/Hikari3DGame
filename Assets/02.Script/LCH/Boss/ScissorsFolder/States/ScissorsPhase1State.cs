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
        if (!_isAttackWait&&!_scissors.IsPhaseEnd)
        {
            _scissors.RigidCompo.velocity = _scissors.player.transform.position*2;
            _scissors.StartCoroutine(PhaseEndCoroutine());
        }

        if (_scissors.IsPhaseEnd)
        {
            _scissors.RigidCompo.velocity = Vector3.zero;
            _scissors.StartCoroutine(ChanseChaseState());
        }
    }

    private IEnumerator ChanseChaseState()
    {
        yield return new WaitForSeconds(1f);
        _scissors.BossStateMachine.ChangeState(BossState.Chase);
    }

    private IEnumerator PhaseEndCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        _scissors.IsPhaseEnd = true;
    }
}