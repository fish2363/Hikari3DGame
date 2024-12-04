using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSharpenerPhase3State : EnemyState<BossState>
{
    public PencilSharpenerPhase3State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
    }
}
