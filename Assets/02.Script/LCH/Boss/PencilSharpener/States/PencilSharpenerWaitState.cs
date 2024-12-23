using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PencilSharpenerWaitState : EntityState
{

    private PencilSharpener _pencilSharpener;

    public PencilSharpenerWaitState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _pencilSharpener = entity as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        _pencilSharpener.StartCoroutine(PhaseSelect());
    }

    private IEnumerator PhaseSelect()
    {
        yield return new WaitForSeconds(0.5F);
        int Phases = /*Random.Range(1,3)*/1;

        switch (Phases)
        {
            case 1:
                _pencilSharpener.ChangeState(BossState.Phase1);
                break;
            case 2:
                _pencilSharpener.ChangeState(BossState.Phase2Wait);
                break;
            case 3:
                _pencilSharpener.ChangeState(BossState.Phase3Wait);
                break;
        }
    }

}
