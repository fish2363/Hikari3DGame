using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase2State : EnemyState<BossState>
{
    private Converse _convers;
    private bool _isAttackWait = true;
    public ConversPhase2State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _convers = enemy as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        _convers.StartCoroutine(WaitAttackCoroutine());
    }

    private IEnumerator WaitAttackCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _isAttackWait = false;
}

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_isAttackWait)
        {
            if (_endTriggerCalled)
            {
                _convers.StartCoroutine(ChangeChaseState());
            }
        }
    }

    private IEnumerator ChangeChaseState()
    {
        yield return new WaitForSeconds(1f);
        _convers.BossStateMachine.ChangeState(BossState.Chase);
    }
}
