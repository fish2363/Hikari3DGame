using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ScissorsPhase2State : EntityState
{
    private Scissors _scissors;
    private bool _isAttackWait;
    private Transform _cameraPos;
    private float _originDamge;

    public ScissorsPhase2State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;
    }

    public override void Enter()
    {
        Debug.Log("´Ï ¿Ö ½ÇÇàµÅ");
        base.Enter();
        _originDamge = _scissors.DamgeCaster.Damage;
        _scissors.DamgeCaster.Damage = 35f;
        _cameraPos = GameObject.FindWithTag("VirtualCamera").transform;
        _scissors.transform.DOMoveY(_scissors.transform.position.y + 25, 1F);
        _scissors.StartCoroutine(AttackEnemy());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _scissors.DamgeCaster.CastDamage();
    }

    private IEnumerator AttackEnemy()
    {
        Debug.Log("A");
        Sequence seq = DOTween.Sequence();
        yield return new WaitForSeconds(0.2f);
        Debug.Log("B");
        _scissors.transform.position =
            new Vector3(_scissors.player.transform.position.x,
        _scissors.transform.position.y,
        _scissors.player.transform.position.z);
        yield return new WaitForSeconds(1f);
        Debug.Log("C");
        _scissors.transform.position =
            new Vector3(_scissors.player.transform.position.x,
        _scissors.transform.position.y,
        _scissors.player.transform.position.z);
        if (seq == null || !seq.IsActive())
        {
            seq = DOTween.Sequence(); 
        } 
        seq.Append(_scissors.transform.DOMove(_scissors.player.transform.position, 0.25f).SetEase(Ease.Linear))
            .AppendCallback(()=>_scissors.StartCoroutine(ChangeChaseState()));

    }

    private IEnumerator ChangeChaseState()
    {
        Debug.Log("A->C");
        yield return new WaitForSeconds(1f);
        _scissors.ChangeState(BossState.Chase);
        _scissors.DamgeCaster.Damage = _originDamge;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
