using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    private Player _player;
    private Coroutine coroutine;

    public DashState(Player player) : base(player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        coroutine = StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {
        yield return null;
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
