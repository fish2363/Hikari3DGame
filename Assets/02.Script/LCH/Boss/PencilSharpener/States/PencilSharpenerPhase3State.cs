using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PencilSharpenerPhase3State : EnemyState<BossState>
{

    private PencilSharpener _pencilSharpener;

    public PencilSharpenerPhase3State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        Sequence seq = DOTween.Sequence();
       seq.Append(_pencilSharpener.transform.DOJump(_pencilSharpener.player.transform.position, 7f, 1, 1.5f)
           .AppendCallback(()=> _pencilSharpener.StartCoroutine(ChangeToChase())));
    }

    private IEnumerator ChangeToChase()
    {
        yield return new WaitForSeconds(1f);
        _pencilSharpener.BossStateMachine.ChangeState(BossState.Chase);
    }
}
