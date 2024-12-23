using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase1State : EntityState
{
    private Scissors _scissors;
    private bool _isAttackWait = true;

    public ScissorsPhase1State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;

    }

    public override void Enter()
    {
        base.Enter();
       _scissors.RigidCompo.velocity = _scissors.player.transform.position*5f;
        _scissors.StartCoroutine(ChanseChaseState());
    }

    private IEnumerator ChanseChaseState()
    {
        yield return new WaitForSeconds(1f);
        _scissors.ChangeState(BossState.Chase);
    }
}
