using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Player player;

    public State(Player owner)
    {
        owner = player;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void StateUpdate()
    {

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
