using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : BossBass
{
    protected override void Awake()
    {
        base.Awake();
        BossStateMachine = new StateMachine<BossState>();
        BossStateMachine.AddState(BossState.Chase, new ScissorsChaseState(this, BossStateMachine,"Chase"));
    }

    private void Start()
    {
        BossStateMachine.InitInitialize(BossState.Chase, this);
    }
}
