using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSharpenerChaseState : EnemyState<BossState>
{
    private PencilSharpener _pencilSharpener;
    public PencilSharpenerChaseState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        _pencilSharpener.StartCoroutine(ChangeWaitState(7));
        _pencilSharpener.IsPhaseEnd = false;
    }

    private IEnumerator ChangeWaitState(int timer)
    {
        yield return new WaitForSeconds(timer);
        _pencilSharpener.BossStateMachine.ChangeState(BossState.Wait);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _pencilSharpener.targetDir = _pencilSharpener.player.transform.position - _pencilSharpener.transform.position;
        _pencilSharpener.RigidCompo.velocity = _pencilSharpener.targetDir.normalized * _pencilSharpener.EnemyStat.MoveSpeed;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
