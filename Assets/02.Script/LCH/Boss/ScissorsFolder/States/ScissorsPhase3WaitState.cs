using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase3WaitState : EnemyState<BossState>
{

    private Scissors _scissors;

    public ScissorsPhase3WaitState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
        _scissors.StartCoroutine(ChangePhase3State());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector3 direction = _scissors.player.transform.position - _scissors.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _scissors.transform.rotation = lookRotation;
        }
    }

    private IEnumerator ChangePhase3State()
    {
        yield return new WaitForSeconds(1f);
        _scissors.BossStateMachine.ChangeState(BossState.Phase3);
    }
}