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
        yield return new WaitForSeconds(0.5f);
        int Phases = /*Random.Range(1, 4);*/ 4;

        switch (Phases)
        {
            case 1:
                _scissors.BossStateMachine.ChangeState(BossState.Phase1Wait);
                Debug.Log("1");
                break;
            case 2:
                _scissors.BossStateMachine.ChangeState(BossState.Phase2Wait);
                Debug.Log("2");
                break;
            case 3:
                _scissors.BossStateMachine.ChangeState(BossState.Phase3Wait);
                Debug.Log("3");
                break;
            case 4:
                _scissors.BossStateMachine.ChangeState(BossState.Phase4Wait);
                Debug.Log("4");
                break;
        }
    }
}
