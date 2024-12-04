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

    [SerializeField] private Vector3 _checkerSize;
    [SerializeField] private LayerMask _whatIsWall;

    public bool WallCheck()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, _checkerSize / 2, Quaternion.identity, _whatIsWall);
        return hitColliders.Length > 0;
    }
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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
    }

}
