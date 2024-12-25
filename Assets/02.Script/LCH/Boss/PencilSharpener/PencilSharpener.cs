using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ami.BroAudio;

public class PencilSharpener : BossBass
{

    [field : SerializeField] public Pencil pencilBelt;
    [field: SerializeField] public Transform shotPos;

    [field : SerializeField] public GameObject _fallingObjectPrefab;

    [field: SerializeField] public SoundID ChaseSound;

    [field: SerializeField] public SoundID ShotPencil;

    [field: SerializeField] public SoundID Phase2Sfx;

    [field: SerializeField] public SoundID Phase3Sfx;


    [field: SerializeField] public Transform JumpPos;
    public DamageCast CastDamge;

    protected override void Awake()
    {
        base.Awake();
        CastDamge = GetComponentInChildren<DamageCast>();
    }

    private void Start()
    {
        _stateMachine.Initialize(BossState.Chase);
    }

    public void InstanceObj(Transform transform, Object prefab, Quaternion qut)
    {
        Instantiate(prefab, transform.position, qut);
    }

}
