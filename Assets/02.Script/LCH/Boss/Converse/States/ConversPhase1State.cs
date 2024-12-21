using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ConversPhase1State : EntityState
{

    private Converse _converse;

    public ConversPhase1State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _converse = entity as Converse;
    }

    public override void Enter()
    {
        Debug.Log("µé¾î°¨");
        base.Enter();
        Sequence seq = DOTween.Sequence();
        seq .Append(_converse.transform.DOJump(_converse.player.transform.position, 7f, 3, 2f).SetEase(Ease.Linear))
            .AppendCallback(()=> _converse.StartCoroutine(ChangeChaseState()));
    }

    private IEnumerator ChangeChaseState()
    {
        yield return new WaitForSeconds(1f);
        _converse.ChangeState(BossState.Chase);
    }
}
