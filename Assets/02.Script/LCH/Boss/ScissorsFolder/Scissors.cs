using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ami.BroAudio;

public class Scissors : BossBass
{

    public Vector3 originPos;

    public DamageCast DamgeCaster;

    [field: SerializeField] public RaycastHit[] hits;

    [field: SerializeField] public LayerMask _groundChecker;

    [field: SerializeField] public LayerMask WhatIsWall;

    [field : SerializeField] public Collider[] colliders;

    [field: SerializeField] public SoundID ScissorsSfx;

    [field: SerializeField] public SoundID ScissorsThrowingSfx;

    [field: SerializeField] public SoundID ScissorsFastSfx;

    [field: SerializeField] public SoundID QuickScissorsSfx;

    [field: SerializeField] public SoundID ScissorsDashSfx;

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
