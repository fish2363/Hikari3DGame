using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase4State : EnemyState<BossState>
{

    private Scissors _scissors;

    public ScissorsPhase4State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
    }
}
