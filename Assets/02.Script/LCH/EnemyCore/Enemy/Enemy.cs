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
    Dead
}
public class Enemy : EnemyAgent
{
    public StateMachine<EnemyStatEnum> stateMachine;
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine<EnemyStatEnum>();
    }

    protected override void EnemyDie()
    {
      
    }

    public void Damage(float AttackDamage)
    {
        hp -= AttackDamage;
    }
}
