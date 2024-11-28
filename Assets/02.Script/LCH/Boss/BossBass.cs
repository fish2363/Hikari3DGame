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
   public StateMachine<BossState> BossStateMachine;
    public bool IsPhaseEnd;

    protected override void EnemyDie()
    {
        
    }
}
