using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private Player _player;
    private const float CONVERT_UNIT_VALUE = 0.01f;

    public MoveState(Player player) : base(player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (_player.InputReader.direction == Vector3.zero)
            _player.ChangeState(StateEnum.Idle);
        else
        {
            float currentMoveSpeed = _player.MoveSpeed * CONVERT_UNIT_VALUE;//속도 맞춰주는 거래요
            LookAt();
            _player.RigidCompo.velocity = _player.InputReader.direction * currentMoveSpeed + Vector3.up * _player.RigidCompo.velocity.y;
        }


    }

    private void LookAt()
    {
        Quaternion targetAngle = Quaternion.LookRotation(_player.InputReader.direction);
        _player.RigidCompo.rotation = targetAngle;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
