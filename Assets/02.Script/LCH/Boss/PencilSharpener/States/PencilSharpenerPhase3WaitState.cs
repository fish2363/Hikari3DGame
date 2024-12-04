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
        _pencilSharpener.transform.LookAt(_pencilSharpener.player.transform.position);
    }

    private IEnumerator ChangePhase3State()
    {
        yield return new WaitForSeconds(1f);
        _pencilSharpener.BossStateMachine.ChangeState(BossState.Phase3);
    }
}
