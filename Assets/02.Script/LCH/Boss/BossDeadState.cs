using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : EntityState
{

    private BossBass _boss;

    private readonly int _deadLayer = LayerMask.NameToLayer("DeadBoss");

    public BossDeadState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _boss = entity as BossBass;
    }

    public override void Enter()
    {
        base.Enter();
        _boss.IsDead = true;
        _boss.gameObject.layer = _deadLayer;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_isTriggerCall)
        {
            _boss.IsDead = false;
            GameObject.Destroy(_boss.gameObject);
        }
    }
}
