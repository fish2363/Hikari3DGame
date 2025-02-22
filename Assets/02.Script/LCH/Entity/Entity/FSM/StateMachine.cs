using System;
using System.Collections.Generic;
using UnityEngine;


public class StateMachine
{
    public EntityState currentState { get; private set; }
        
    private Dictionary<BossState, EntityState> _stateDictionary;

    public StateMachine(EntityFSMSO entityStates, Entity entity)
    {
        _stateDictionary = new Dictionary<BossState, EntityState>();
        
        foreach (StateSO state in entityStates.states)
        {
            try
            {
                Type type = Type.GetType(state.className);
                var entityState = Activator.CreateInstance(type, entity, state.animParam) as EntityState;
                _stateDictionary.Add(state.stateName, entityState);
            }
            catch (Exception e)
            {
                Debug.LogError($"{state.className} loading error, Message : {e.Message}");
            }
        }
    }
    
    public EntityState GetState(BossState state)
    {
        return _stateDictionary.GetValueOrDefault(state);
    }
    
    public void Initialize(BossState startState)
    {
        currentState = GetState(startState);
        currentState.Enter();
    }

    public void UpdateStateMachine()
    {
        currentState.UpdateState();
    }
    
    public void ChageState(BossState newState)
    {
        currentState.Exit();
        EntityState nextState = GetState(newState);
        Debug.Assert(nextState != null, $"State : {newState} not found");
        
        currentState = nextState;
        currentState.Enter();
    }

}
