using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyState<T> where T : Enum
{
    protected Enemy _enemy;
    protected int _animBoolHash;
    protected StateMachine<T> _stateMachine;
    protected bool _endTriggerCalled;

    public EnemyState(Enemy enemy, StateMachine<T> state, string animHashName)
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
        //_enemy.AnimatorComponent.SetBool(_animBoolHash, true);
        _endTriggerCalled = false;

    }
    public virtual void Exit()
    {
        //_enemy.AnimatorComponent.SetBool(_animBoolHash, false);
    }

    public virtual void LateUpdateState()
    {

    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
}
