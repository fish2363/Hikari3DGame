using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ScissorsPhase2State : EnemyState<BossState>
{
    private Scissors _scissors;
    private bool _isAttackWait;
    private Transform _cameraPos;
    private Sequence sequence;
    public ScissorsPhase2State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
    }

    public override void Enter()
    {
        base.Enter();
        _cameraPos = GameObject.FindWithTag("VirtualCamera").transform;
        _scissors.transform.DOMoveY(_scissors.transform.position.y + 25, 1F);
        _scissors.RigidCompo.useGravity = false;
        _scissors.StartCoroutine(AttackEnemy());
    }

    public override void UpdateState()
    {
        base.UpdateState();
      
    }

    private IEnumerator AttackEnemy()
    {
        _scissors.transform.position =
            new Vector3(_scissors.player.transform.position.x,
        _scissors.transform.position.y,
        _scissors.player.transform.position.z);
        yield return new WaitForSeconds(1f);
        _scissors.transform.position =
            new Vector3(_scissors.player.transform.position.x,
        _scissors.transform.position.y,
        _scissors.player.transform.position.z);
        _scissors.RigidCompo.useGravity = true;
        _scissors.transform.DOMove(_scissors.player.transform.position, 0.25f);

    }

}
