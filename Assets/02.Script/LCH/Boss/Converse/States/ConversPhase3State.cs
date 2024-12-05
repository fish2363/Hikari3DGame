using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase3State : EnemyState<BossState>
{
    private Converse _convers;
    public ConversPhase3State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _convers = enemy as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        _convers.RigidCompo.AddForce(_convers.player.transform.position* 7f,ForceMode.Impulse);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_convers.WallChecker)
        {
            _convers.RigidCompo.velocity = Vector3.zero;
            _convers.StartCoroutine(ChangeChaseState());
        }
    }

    private IEnumerator ChangeChaseState()
    {
        _convers.WallChecker = false;
        yield return new WaitForSeconds(1f);
        _convers.BossStateMachine.ChangeState(BossState.Chase);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
