using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSharpenerPhase3WaitState : EnemyState<BossState>
{

    private PencilSharpener _pencilSharpener;
    public PencilSharpenerPhase3WaitState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        _pencilSharpener.StartCoroutine(ChangePhase3State());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector3 direction = _pencilSharpener.player.transform.position - _pencilSharpener.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _pencilSharpener.transform.rotation = lookRotation;
        }
    }

    private IEnumerator ChangePhase3State()
    {
        yield return new WaitForSeconds(1f);
        _pencilSharpener.BossStateMachine.ChangeState(BossState.Phase3);
    }
}