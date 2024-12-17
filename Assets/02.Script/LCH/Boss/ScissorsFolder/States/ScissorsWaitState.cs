using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScissorsWaitState : EnemyState<BossState>
{
    private Scissors _scissors;
    public ScissorsWaitState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
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
                _scissors.BossStateMachine.ChangeState(BossState.Phase1Wait);
                break;
            case 2:
                _scissors.BossStateMachine.ChangeState(BossState.Phase2Wait);
                Debug.Log("이거때문이지롱");
                break;
            case 3:
                _scissors.BossStateMachine.ChangeState(BossState.Phase3Wait);
                break;
            case 4:
                _scissors.BossStateMachine.ChangeState(BossState.Phase4Wait);
                break;
        }
    }
}
