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
        BossStateMachine.AddState(BossState.Wait, new ScissorsWaitState(this, BossStateMachine,"Wait"));
        BossStateMachine.AddState(BossState.Phase1, new ScissorsPhase1State(this, BossStateMachine,"Phase1"));
    }

    private void Start()
    {
        BossStateMachine.InitInitialize(BossState.Chase, this);
    }

    private void Update()
    {
        BossStateMachine.CurrentState.UpdateState();
    }
}
