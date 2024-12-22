using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitState : EntityState
{
    private BossBass _boss;
    public BossHitState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _boss = entity as BossBass;
    }

    public override void Enter()
    {
        base.Enter();

        var item = GameObject.Instantiate(_boss.effet);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}

