using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversWaitState : EnemyState<BossState>
{

    private Converse _converse;
    public ConversWaitState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _converse = enemy as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        _converse.StartCoroutine(PhaseSelect());
    }

    private IEnumerator PhaseSelect()
    {
        yield return new WaitForSeconds(0.5F);
        int Phases = Random.Range(1, 4);

        switch (Phases)
        {
            case 1:
                _converse.BossStateMachine.ChangeState(BossState.Phase1Wait);
                break;
            case 2:
                _converse.BossStateMachine.ChangeState(BossState.Phase2Wait);
                break;
            case 3:
                _converse.BossStateMachine.ChangeState(BossState.Phase3Wait);
                break;
            case 4:
                _converse.BossStateMachine.ChangeState(BossState.Phase4Wait);
                break;
        }
    }
}
