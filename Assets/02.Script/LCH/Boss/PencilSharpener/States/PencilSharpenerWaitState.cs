using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSharpenerWaitState : EnemyState<BossState>
{

    private PencilSharpener _pencilSharpener;

    public PencilSharpenerWaitState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        _pencilSharpener.StartCoroutine(PhaseSelect());
    }

    private IEnumerator PhaseSelect()
    {
        yield return new WaitForSeconds(0.5F);
        int Phases = /*Random.Range(1, 3);*/ 1;

        switch (Phases)
        {
            case 1:
                _pencilSharpener.BossStateMachine.ChangeState(BossState.Phase1);
                break;
            case 2:
                _pencilSharpener.BossStateMachine.ChangeState(BossState.Phase2);
                break;
            case 3:
                _pencilSharpener.BossStateMachine.ChangeState(BossState.Phase3);
                break;
        }
    }

}
