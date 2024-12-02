using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSharpener : BossBass
{

    [field : SerializeField] public Pencil pencilBelt;
    [field: SerializeField] public Transform shotPos;

    protected override void Awake()
    {
        base.Awake();
        BossStateMachine = new StateMachine<BossState>();
        BossStateMachine.AddState(BossState.Chase, new PencilSharpenerChaseState(this, BossStateMachine, "Chase"));
        BossStateMachine.AddState(BossState.Wait, new PencilSharpenerWaitState(this, BossStateMachine, "Wait"));
        BossStateMachine.AddState(BossState.Phase1, new PencilSharpenerPhase1(this, BossStateMachine, "Phase1"));
        BossStateMachine.AddState(BossState.Phase2, new ConversPhase2State(this, BossStateMachine, "Phase2"));
        BossStateMachine.AddState(BossState.Phase3, new ConversPhase3State(this, BossStateMachine, "Phase3"));
    }
    private void Start()
    {
        BossStateMachine.InitInitialize(BossState.Chase, this);
    }

    public void InstanceObj(Transform transform, Object prefab, Quaternion qut)
    {
        Instantiate(prefab, transform.position, qut);
    }

}
