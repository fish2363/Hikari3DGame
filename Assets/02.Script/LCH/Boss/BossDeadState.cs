using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : EntityState
{

    private BossBass _boss;

    public BossDeadState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _boss = entity as BossBass;
    }
}
