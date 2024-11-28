using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase1State : EnemyState<BossState>
{

    private Converse _converse;
    private bool _isAttackWait = true;
    public ConversPhase1State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _converse = enemy as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        _converse.StartCoroutine(AttackWaitCoroutine());
    }

    private IEnumerator AttackWaitCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _isAttackWait = false;
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(!_isAttackWait && !_converse.IsPhaseEnd)
        {
            //_converse.RigidCompo.AddForce(Vector3.up )
        }
    }
}
