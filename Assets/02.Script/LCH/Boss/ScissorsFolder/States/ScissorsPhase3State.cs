using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase3State : EntityState
{
    private Scissors _scissors;
    private bool _isAttackWait = true;
    private float originMoveSpeed = 0f;
    private float _originDamge;

    public ScissorsPhase3State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;
    }

    public override void Enter()
    {
        base.Enter();
        _originDamge += _scissors.DamgeCaster.Damage;
        _scissors.DamgeCaster.Damage = 20f;
        originMoveSpeed = _scissors.EnemyStat.ChasingSpeed;
        _scissors.EnemyStat.ChasingSpeed = 10f;
     
        _scissors.StartCoroutine(PlayerChase());
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _scissors.targetDir = _scissors.player.transform.position - _scissors.transform.position;
        _scissors.RigidCompo.velocity = _scissors.targetDir.normalized * _scissors.EnemyStat.ChasingSpeed;
    }

    private IEnumerator PlayerChase()
    {
        yield return new WaitForSeconds(7f);
        _scissors.StartCoroutine(ChanseChaseState());
    }

    private IEnumerator ChanseChaseState()
    {
        if (!_scissors.IsDead)
        {
            yield return new WaitForSeconds(1f);
            _scissors.ChangeState(BossState.Chase);
            _scissors.EnemyStat.ChasingSpeed = originMoveSpeed;
            _scissors.DamgeCaster.Damage = _originDamge;
            
        }
    }
}
