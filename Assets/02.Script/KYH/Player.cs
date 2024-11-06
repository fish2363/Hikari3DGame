using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float MaxHp { get { return maxHp; } }
    public float CurrentHp { get { return currentHp; } }
    public float MoveSpeed { get { return moveSpeed; } }

    protected float maxHp;
    protected float currentHp;
    protected float moveSpeed;

    private Dictionary<StateEnum, State> stateDictionary = new Dictionary<StateEnum, State>();
    private StateEnum currentEnum;

    private void Awake()
    {
        foreach(StateEnum enumState in Enum.GetValues(typeof(StateEnum)))
        {
            Type t = Type.GetType($"{enumState}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            stateDictionary.Add(enumState,state);
        }
        ChangeState(StateEnum.Idle);
    }

    public void ChangeState(StateEnum newEnum)
    {
        stateDictionary[currentEnum].Exit();
        currentEnum = newEnum;
        stateDictionary[currentEnum].Enter();
    }
}
