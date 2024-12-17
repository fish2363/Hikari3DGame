using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyState<T> where T : Enum
{
    protected EnemyAgent _enemy;
    protected int _animBoolHash;
    protected StateMachine<T> _stateMachine;
    protected bool _endTriggerCalled;

    public EnemyState(EnemyAgent enemy, StateMachine<T> state, string animHashName)
    {
        _enemy = enemy;
        _stateMachine = state;
        _animBoolHash = Animator.StringToHash(animHashName);
    }

    public virtual void UpdateState()
    {

    }

    public virtual void Enter()
    {
        _enemy.AnimCompo.SetBool(_animBoolHash, true);
        _endTriggerCalled = false;

    }
    public virtual void Exit()
    {
        _enemy.AnimCompo.SetBool(_animBoolHash, false);
    }

    public virtual void LateUpdateState()
    {

    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
}
