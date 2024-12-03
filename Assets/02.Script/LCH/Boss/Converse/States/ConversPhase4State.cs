using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase4State : EnemyState<BossState>
{

    private Converse _converse;
    private bool _isAttackWait = true;
    public ConversPhase4State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _converse = enemy as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        _converse.StartCoroutine(WaitAttackCoroutine());
        _converse.EnemyStat.MoveSpeed = 7f;
    }

    private IEnumerator WaitAttackCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _isAttackWait = false;
        _converse.StartCoroutine(PhaseEndCoroutine());
    }

    private IEnumerator PhaseEndCoroutine()
    {
        yield return new WaitForSeconds(7f);
        _converse.IsPhaseEnd = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_isAttackWait && !_converse.IsPhaseEnd)
        {
            _converse.targetDir = _converse.player.transform.position - _converse.transform.position;
            _converse.RigidCompo.velocity = _converse.targetDir.normalized * _converse.EnemyStat.MoveSpeed;
        }

        if (_converse.IsPhaseEnd)
        {
            _converse.RigidCompo.velocity = Vector3.zero;
            _converse.StartCoroutine(ChangeChaseState());
        }
    }

    private IEnumerator ChangeChaseState()
    {
        yield return new WaitForSeconds(1f);
        _converse.BossStateMachine.ChangeState(BossState.Chase);
    }
}
