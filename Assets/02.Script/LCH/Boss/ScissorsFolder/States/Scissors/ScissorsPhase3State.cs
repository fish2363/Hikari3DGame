using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase3State : EnemyState<BossState>
{
    private Scissors _scissors;
    private bool _isAttackWait = true;
    private float originMoveSpeed = 0f;
    public ScissorsPhase3State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
    }

    public override void Enter()
    {
        base.Enter();
        _scissors.StartCoroutine(AttackWaitCoroutine());
        originMoveSpeed = _scissors.EnemyStat.MoveSpeed;
        _scissors.EnemyStat.MoveSpeed = 10f;
        
    }

    private IEnumerator AttackWaitCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _isAttackWait = false;

        _scissors.StartCoroutine(PhaseEndCoroutine());
    }

    private IEnumerator PhaseEndCoroutine()
    {
        yield return new WaitForSeconds(7f);
        _scissors.IsPhaseEnd = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_scissors.IsPhaseEnd && !_isAttackWait)
        {
            _scissors.targetDir = _scissors.player.transform.position - _scissors.transform.position;
            _scissors.RigidCompo.velocity = _scissors.targetDir.normalized * _scissors.EnemyStat.MoveSpeed;
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

    public override void Exit()
    {
        base.Exit();
        _scissors.EnemyStat.MoveSpeed = originMoveSpeed;
    }
}
