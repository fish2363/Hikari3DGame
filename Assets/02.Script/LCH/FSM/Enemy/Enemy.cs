using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EnemyStatEnum
{
    Idle,
    Jump,
    Walk,
    Attack,
    Skill,
    Dead
}
public class Enemy : EnemySetting
{

    public StateMachine<EnemyStatEnum> stateMachine;
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine<EnemyStatEnum>();
    }
}
