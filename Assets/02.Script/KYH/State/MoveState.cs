using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

public class MoveState : State
{
    private Player _player;
    private const float CONVERT_UNIT_VALUE = 0.01f;


    private const float RAY_DISTANCE = 2f;
    private RaycastHit slopeHit;
    private int groundLayer = 1 << LayerMask.NameToLayer("Ground");
    private float maxSlopeAngle;
    private float rotateSpeed = 20f;

    Vector3 moveDir;

    public MoveState(Player player) : base(player)
    {
        _player = player;
    }

    public override void Enter()
    {
        print("Okay");
        base.Enter();
    }

   
    public bool IsOnSlope()
    {
        Ray ray = new(_player.transform.position, Vector3.down);
        if(Physics.Raycast(ray, out slopeHit, RAY_DISTANCE, groundLayer))
        {
            var angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle != 0f && angle < maxSlopeAngle;
        }

        return false;
    }

    public Vector3 AdjustDirectionToSlope(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }
    float smoothTime = 0.1f;
    float turnSmoothVelocity;

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        float animationSpeed;

        if (_player.InputReader.direction == Vector3.zero)
        {
            _player.ChangeState(StateEnum.Idle);
            animationSpeed = 0;
            _player.animator.SetFloat("Velocity", animationSpeed);
        }
        else
        {
            float currentMoveSpeed = _player.MoveSpeed * CONVERT_UNIT_VALUE;//속도 맞춰주는 거래요
            animationSpeed = 1f;
            bool isOnSlope = IsOnSlope();
            bool isGrounded = _player.GroundCheck.IsGrounded();
            Vector3 velocity = isOnSlope ? AdjustDirectionToSlope(moveDir.normalized) : moveDir.normalized;
            Vector3 gravity = isOnSlope ? Vector3.zero : Vector3.down * Mathf.Abs(_player.RigidCompo.velocity.y);

            if (isGrounded && isOnSlope)
            {
                velocity = AdjustDirectionToSlope(_player.InputReader.direction);
                gravity = Vector3.zero;
                _player.RigidCompo.useGravity = false;
            }
            else
            {
                _player.RigidCompo.useGravity = true;
            }

            LookAt();
            //_player.ControllerCompo.Move(velocity * currentMoveSpeed + gravity);
            _player.RigidCompo.velocity = velocity * currentMoveSpeed + gravity;
            _player.animator.SetFloat("Velocity", animationSpeed);
        }

    }

    public void GetCommonMoveVectorFromPlayerInput(float x, float y, Quaternion cameraRotation, out Vector3 moveVector)
    {
        moveVector = (math.mul(cameraRotation, math.right()) * x) + (math.mul(cameraRotation, math.forward()) * y);
    }

    private void LookAt()
    {
        var rot = Camera.main.transform.rotation;
        Vector3 moveVector;
        GetCommonMoveVectorFromPlayerInput(_player.InputReader.direction.x, _player.InputReader.direction.z, rot, out moveVector);

        Quaternion targetAngle = Quaternion.LookRotation(moveVector);
        _player.transform.rotation = Quaternion.Lerp(
        _player.transform.rotation, targetAngle, Time.deltaTime * rotateSpeed);

        //_player.transform.forward = moveVector;
        moveDir = moveVector;
        moveDir.y = 0;

        Debug.Log($"x:{_player.InputReader.direction.x} y:{_player.InputReader.direction.y} dir:{moveDir}");
    }

    public override void Exit()
    {
        base.Exit();
    }
}
