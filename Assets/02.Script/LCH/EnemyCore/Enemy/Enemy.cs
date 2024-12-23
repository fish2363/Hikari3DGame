using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public enum EnemyStatEnum
{
    Idle,
    Jump,
    Walk,
    Chase,
    Attack,
    Skill,
    Dead,
    Stun
}
public abstract class Enemy : EnemyAgent
{
    public StateMachine<EnemyStatEnum> stateMachine;
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine<EnemyStatEnum>();
    }

    public void StopImmediately()
    {
        RigidCompo.velocity = Vector3.zero;
    }

    protected abstract void AnimEndTrigger();
}
