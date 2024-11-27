using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Idle,
    Wait,
    Phase1,
    Phase2,
    Phase3,
    Phase4,
    Die,
    Hit,
}

public class Scissors : EnemyAgent
{
    public StateMachine<BossState> BossStateMachine;
    protected override void Awake()
    {
        base.Awake();
        BossStateMachine = new StateMachine<BossState>();
    }

    protected override void EnemyDie()
    {
        
    }
}
