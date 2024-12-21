using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase2State : EntityState
{
    private Converse _converse;

    public ConversPhase2State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _converse = entity as Converse;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_isTriggerCall)
        {
            Debug.Log("³¡¤¤");
            _converse.StartCoroutine(ChangeChaseState());
            _isTriggerCall = false;
        }
    }

    private IEnumerator ChangeChaseState()
    {
        yield return new WaitForSeconds(1f);
        _converse.ChangeState(BossState.Chase);
    }
}
