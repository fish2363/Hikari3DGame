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

    public ScissorsPhase2State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;
    }

    public override void Enter()
    {
        Debug.Log("�� �� �����");
        base.Enter();
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
        Sequence seq = DOTween.Sequence();
        yield return new WaitForSeconds(0.2f);
        _scissors.transform.position =
            new Vector3(_scissors.player.transform.position.x,
        _scissors.transform.position.y,
        _scissors.player.transform.position.z);
        yield return new WaitForSeconds(1f);
        _scissors.transform.position =
            new Vector3(_scissors.player.transform.position.x,
        _scissors.transform.position.y,
        _scissors.player.transform.position.z);
        seq.Append(_scissors.transform.DOMove(_scissors.player.transform.position, 0.25f).SetEase(Ease.Linear))
            .AppendCallback(()=>_scissors.StartCoroutine(ChangeChaseState()));

    }

    private IEnumerator ChangeChaseState()
    {
        Debug.Log("A->C");
        yield return new WaitForSeconds(1f);
        _scissors.ChangeState(BossState.Chase);
    }
}
