using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase3State : EnemyState<BossState>
{
    private Converse _convers;
    public ConversPhase3State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _convers = enemy as Converse;
    }  
}
