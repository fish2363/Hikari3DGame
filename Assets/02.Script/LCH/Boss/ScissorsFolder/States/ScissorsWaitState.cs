using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScissorsWaitState : EntityState
{
    private Scissors _scissors;

    public ScissorsWaitState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;

    }

    public override void Enter()
    {
        base.Enter();
        _scissors.StartCoroutine(PhaseSelect());
    }

    private IEnumerator PhaseSelect()
    {
        yield return new WaitForSeconds(0.5F);
        int Phases = Random.Range(1, 4);;

        switch (Phases)
        {
            case 1:
                _scissors.ChangeState(BossState.Phase1Wait);
                break;
            case 2:
                _scissors.ChangeState(BossState.Phase2Wait);
                Debug.Log("이거때문이지롱");
                break;
            case 3:
                _scissors.ChangeState(BossState.Phase3Wait);
                break;
            case 4:
                _scissors.ChangeState(BossState.Phase4Wait);
                break;
        }
    }
}
