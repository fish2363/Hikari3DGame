using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Wait,
    Chase,
    Phase1,
    Phase1Wait,
    Phase2,
    Phase2Wait,
    Phase3,
    Phase3Wait,
    Phase4,
    Phase4Wait,
    Die
}

[CreateAssetMenu(fileName = "EntityFSMSO", menuName = "SO/FSM/EntityFSM")]
public class EntityFSMSO : ScriptableObject
{
    public List<StateSO> states;
    private Dictionary<BossState, StateSO> _statesDictionary;

    public StateSO this[BossState stateName] => _statesDictionary.GetValueOrDefault(stateName);

    private void OnEnable()
    {
        if (states == null) return;
        
        _statesDictionary = new Dictionary<BossState, StateSO>();
        foreach (var state in states)    
        {
            _statesDictionary.Add(state.stateName, state);
        }
    }
}
