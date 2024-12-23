using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PencilSharpenerPhase3State : EntityState
{

    private PencilSharpener _pencilSharpener;
    private float _oringinDamge;

    public PencilSharpenerPhase3State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _pencilSharpener = entity as PencilSharpener;

    }

    public override void Enter()
    {
        base.Enter();
        _oringinDamge = _pencilSharpener.CastDamge.Damage;
        _pencilSharpener.CastDamge.Damage = 35f;
        Sequence seq = DOTween.Sequence();
       seq.Append(_pencilSharpener.transform.DOJump(_pencilSharpener.player.transform.position, 7f, 1, 1.5f)
           .AppendCallback(()=> _pencilSharpener.StartCoroutine(ChangeToChase())));
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _pencilSharpener.CastDamge.CastDamage();
    }

    private IEnumerator ChangeToChase()
    {
        yield return new WaitForSeconds(1f);
        _pencilSharpener.ChangeState(BossState.Chase);
    }

    public override void Exit()
    {
        base.Exit();
        _pencilSharpener.CastDamge.Damage = _oringinDamge;
    }
}
