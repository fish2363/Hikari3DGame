using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : BossBass
{

    public Vector3 originPos;
    public bool isGround;

    protected override void Awake()
    {
        base.Awake();
        BossStateMachine = new StateMachine<BossState>();
        BossStateMachine.AddState(BossState.Chase, new ScissorsChaseState(this, BossStateMachine,"Chase"));
        BossStateMachine.AddState(BossState.Wait, new ScissorsWaitState(this, BossStateMachine,"Wait"));
        BossStateMachine.AddState(BossState.Phase1Wait, new ScissorsPhase1Wait(this, BossStateMachine, "Phase1"));
        BossStateMachine.AddState(BossState.Phase1, new ScissorsPhase1State(this, BossStateMachine,"Phase1"));
        BossStateMachine.AddState(BossState.Phase2Wait, new ScissorsPhase2WaitState(this, BossStateMachine, "PhaseWait2"));
        BossStateMachine.AddState(BossState.Phase2, new ScissorsPhase2State(this, BossStateMachine,"Phase2"));
        BossStateMachine.AddState(BossState.Phase3Wait, new ScissorsPhase3State(this, BossStateMachine,"Phase3Wait"));
        BossStateMachine.AddState(BossState.Phase3, new ScissorsPhase3State(this, BossStateMachine,"Phase3"));
        BossStateMachine.AddState(BossState.Phase4Wait, new ScissorsPhase4WaitState(this, BossStateMachine,"Phase4Wait"));
        BossStateMachine.AddState(BossState.Phase4, new ScissorsPhase4State(this, BossStateMachine,"Phase4"));
        
    }


    private void Start()
    {
        BossStateMachine.InitInitialize(BossState.Chase, this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
