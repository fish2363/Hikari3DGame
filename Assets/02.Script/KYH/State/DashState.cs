using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    private Player _player;

    public DashState(Player player) : base(player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        _player.isDash = true;
        _player.isBlock = true;
        _player.animator.SetFloat("Velocity", 0f);
        if (_player.velocity == Vector3.zero) _player.velocity = _player.transform.forward;
        _player.DashCool();
    }
}
