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
        BossStateMachine.AddState(BossState.Phase1Wait, new ConversPhase1WaitState(this, BossStateMachine, "Phase1Wait"));
        BossStateMachine.AddState(BossState.Phase2, new ConversPhase2State(this, BossStateMachine, "Phase2"));
        BossStateMachine.AddState(BossState.Phase2Wait, new ConversePhase2WaitState(this, BossStateMachine, "Phase2Wait"));
        BossStateMachine.AddState(BossState.Phase3, new ConversPhase3State(this, BossStateMachine, "Phase3"));
        BossStateMachine.AddState(BossState.Phase3Wait, new ConversPhase3WaitState(this, BossStateMachine, "Phase3Wait"));
        BossStateMachine.AddState(BossState.Phase4, new ConversPhase4State(this, BossStateMachine, "Phase4"));
        BossStateMachine.AddState(BossState.Phase4Wait, new ConversPhase4WaitState(this, BossStateMachine, "Phase4Wait"));
    }
    private void Start()
    {
        BossStateMachine.InitInitialize(BossState.Chase, this);
    }

}
