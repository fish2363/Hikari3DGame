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

    public virtual void Enter()
    {
        
    }

    public virtual void StateUpdate()
    {

    }

    public virtual void StateFixedUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
