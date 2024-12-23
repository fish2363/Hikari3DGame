using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PencilSharpenerChaseState : EntityState
{
    private PencilSharpener _pencilSharpener;
    private int timer;

    public PencilSharpenerChaseState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _pencilSharpener = entity as PencilSharpener;
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
        if (!_pencilSharpener.IsDead)
        {
            yield return new WaitForSeconds(timer);
            _pencilSharpener.ChangeState(BossState.Wait);
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _pencilSharpener.StartCoroutine(DamgeToPlayer());
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

    private IEnumerator DamgeToPlayer()
    {
        yield return new WaitForSeconds(0.7f);
        _pencilSharpener.CastDamge.CastDamage();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
