using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ConversPhase1State : EnemyState<BossState>
{

    private Converse _converse;

    public ConversPhase1State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _converse = enemy as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1)
            .Append(_converse.transform.DOJump(_converse.player.transform.position, 7f, 3, 2f).SetEase(Ease.Linear))
            .AppendCallback(()=> _converse.StartCoroutine(ChangeChaseState()));
    }

    private IEnumerator ChangeChaseState()
    {
        yield return new WaitForSeconds(1f);
        _converse.BossStateMachine.ChangeState(BossState.Chase);
    }
}
