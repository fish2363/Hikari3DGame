using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase4WaitState : EnemyState<BossState>
{
    private Converse _converse;

    public ConversPhase4WaitState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _converse = enemy as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        _converse.StartCoroutine(ChangePhase1State());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _converse.transform.LookAt(_converse.player.transform.position);
    }

    private IEnumerator ChangePhase1State()
    {
        yield return new WaitForSeconds(1f);
        _converse.BossStateMachine.ChangeState(BossState.Phase4);
    }
}
