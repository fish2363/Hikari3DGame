using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase2State : EnemyState<BossState>
{
    private Converse _convers;
    public ConversPhase2State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _convers = enemy as Converse;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            _convers.StartCoroutine(ChangeChaseState());
            _endTriggerCalled = false;
        }
    }

    private IEnumerator ChangeChaseState()
    {
        yield return new WaitForSeconds(1f);
        _convers.BossStateMachine.ChangeState(BossState.Chase);
    }
}
