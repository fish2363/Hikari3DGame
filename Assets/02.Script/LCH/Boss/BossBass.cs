using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Wait,
    Chase,
    Phase1,
    Phase1Wait,
    Phase2,
    Phase2Wait,
    Phase3,
    Phase3Wait,
    Phase4,
    Phase4Wait,
    Die,
    Hit,
}

public abstract class BossBass : EnemyAgent
{
   public StateMachine<BossState> BossStateMachine;
    public bool IsPhaseEnd;
    public bool WallChecker = false;
    public void AnimEndTrigger()
    {
        BossStateMachine.CurrentState.AnimationEndTrigger();
    }

    protected override void EnemyDie()
    {
        
    }

    protected virtual void Update()
    {
        BossStateMachine.CurrentState.UpdateState();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallChecker = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        WallChecker = false;
    }
}
