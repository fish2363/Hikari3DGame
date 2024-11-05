using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Player player;

    public State(Player owner)
    {
        owner = player;
    }

    public void Enter()
    {
        
    }

    public void StateUpdate()
    {

    }

    public void Exit()
    {

    }
}
