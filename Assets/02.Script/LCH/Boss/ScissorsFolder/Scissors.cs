using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : BossBass
{

    public Vector3 originPos;

    public DamageCast DamgeCaster;

    protected override void Awake()
    {
        base.Awake();
        DamgeCaster = GetComponentInChildren<DamageCast>();
    }

    private void Start()
    {
        _stateMachine.Initialize(BossState.Chase);
    }
}
