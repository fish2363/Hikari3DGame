using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : BossBass
{

    public Vector3 originPos;

    public DamageCast DamgeCaster;

    [field: SerializeField] public RaycastHit[] hits;

    [field: SerializeField] public LayerMask _groundChecker;

    [field: SerializeField] public LayerMask WhatIsWall;

    [field : SerializeField] public Collider[] colliders;

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
