using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converse : BossBass
{

    protected override void Awake()
    {
        base.Awake();
        BossStateMachine = new StateMachine<BossState>();
        BossStateMachine.AddState(BossState.Chase, new ConverseChaseState(this, BossStateMachine, "Chase"));
        BossStateMachine.AddState(BossState.Wait, new ConversWaitState(this, BossStateMachine, "Wait"));
        BossStateMachine.AddState(BossState.Phase1, new ConversPhase1State(this, BossStateMachine, "Phase1"));
        BossStateMachine.AddState(BossState.Phase2, new ConversPhase2State(this, BossStateMachine, "Phase2"));
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
