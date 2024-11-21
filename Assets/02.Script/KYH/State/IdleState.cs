using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private Player _player;


    public IdleState(Player player) : base(player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        _player.RigidCompo.velocity = Vector3.zero;
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (_player.InputReader.direction != Vector3.zero)
            _player.ChangeState(StateEnum.Move);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
