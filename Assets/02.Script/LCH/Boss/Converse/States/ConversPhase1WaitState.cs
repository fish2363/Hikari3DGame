using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase1WaitState : EnemyState<BossState>
{

    private Converse _converse;

    public ConversPhase1WaitState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
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
        Vector3 direction = _converse.player.transform.position - _converse.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _converse.transform.rotation = lookRotation;
        }
    }

    private IEnumerator ChangePhase1State()
    {
        yield return new WaitForSeconds(1f);
        _converse.BossStateMachine.ChangeState(BossState.Phase1);
    }
}
