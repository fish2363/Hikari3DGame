using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSharpenerPhase1 : EnemyState<BossState>
{
    private PencilSharpener _pencilSharpener;
    private bool _isAttackWait = true;
    public PencilSharpenerPhase1(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        _pencilSharpener.RigidCompo.AddForce(Vector3.up * 4,ForceMode.Impulse);
        _pencilSharpener.StartCoroutine(AttackWaitCoroutine());
    }

    private IEnumerator AttackWaitCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _isAttackWait = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(_pencilSharpener.RigidCompo.velocity.y < 0)
        {
            _pencilSharpener.RigidCompo.useGravity = false;
        }

        _pencilSharpener.transform.LookAt(_pencilSharpener.player.transform.position);

        if(!_isAttackWait && !_pencilSharpener.IsPhaseEnd)
        {
            _pencilSharpener.InstanceObj(_pencilSharpener.shotPos , _pencilSharpener.pencilBelt, Quaternion.identity);
        }
    }
}
