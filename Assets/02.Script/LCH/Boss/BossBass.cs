using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Wait,
    Chase,
    Phase1,
    Phase2,
    Phase3,
    Phase4,
    Die,
    Hit,
}

public abstract class BossBass : EnemyAgent
{
   protected StateMachine<BossState> BossStateMachine;

    protected override void EnemyDie()
    {
        
    }
}
