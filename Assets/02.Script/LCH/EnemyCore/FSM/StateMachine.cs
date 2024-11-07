using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : Enum
{
	public Dictionary<T, EnemyState<T>> EnemyDict = new Dictionary<T, EnemyState<T>>();

	public EnemyState<T> CurrentState { get; private set; }

	private Enemy _enemy;

	public void InitInitialize(T state,Enemy enemy)
    {
		_enemy = enemy;
		CurrentState = EnemyDict[state];
		CurrentState.Enter();
    }

	public void ChangeState(T changeState)
	{
		CurrentState.Exit();
		CurrentState = EnemyDict[changeState];
		CurrentState.Enter();
	}

	public void AddState(T stateEnum, EnemyState<T> state)
	{
		EnemyDict.Add(stateEnum, state);
	}
}
