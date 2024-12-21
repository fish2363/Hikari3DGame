using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase3State : EntityState
{
    private Converse _converse;

    public ConversPhase3State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _converse = entity as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        _converse.RigidCompo.AddForce(_converse.player.transform.position* 7f,ForceMode.Impulse);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_converse.WallChecker)
        {
            _converse.RigidCompo.velocity = Vector3.zero;
            _converse.StartCoroutine(ChangeChaseState());
        }
    }

    private IEnumerator ChangeChaseState()
    {
        _converse.WallChecker = false;
        yield return new WaitForSeconds(1f);
        _converse.ChangeState(BossState.Chase);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
