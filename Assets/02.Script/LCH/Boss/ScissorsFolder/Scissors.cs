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
        BossStateMachine.AddState(BossState.Phase2, new ScissorsPhase2State(this, BossStateMachine,"Phase2"));
        BossStateMachine.AddState(BossState.Phase3, new ScissorsPhase3State(this, BossStateMachine,"Phase3"));
    }


    private void Start()
    {
        BossStateMachine.InitInitialize(BossState.Chase, this);
    }
    protected override void AnimEndTrigger()
    {
        BossStateMachine.CurrentState.AnimationEndTrigger();
    }
    protected override void EnemyDie()
    {
        
    }
}
