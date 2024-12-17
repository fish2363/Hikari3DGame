using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PencilSharpenerChaseState : EnemyState<BossState>
{
    private PencilSharpener _pencilSharpener;
    private int timer;
    public PencilSharpenerChaseState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("µé¾î°¨");
        timer = Random.Range(4, 7);
        _pencilSharpener.StartCoroutine(ChangeWaitState(timer));
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
        Vector3 direction = _pencilSharpener.player.transform.position - _pencilSharpener.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _pencilSharpener.transform.rotation = lookRotation;
        }
        _pencilSharpener.targetDir = _pencilSharpener.player.transform.position - _pencilSharpener.transform.position;
        _pencilSharpener.RigidCompo.velocity = _pencilSharpener.targetDir.normalized * _pencilSharpener.EnemyStat.ChasingSpeed;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
