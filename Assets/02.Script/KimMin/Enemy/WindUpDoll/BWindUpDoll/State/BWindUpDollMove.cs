using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BWindUpDollMove : EnemyState<EnemyStatEnum>
{
    private Vector3 _next;
    private Vector3 _prev;
    private BWindUpDoll _windUpDoll;

    public BWindUpDollMove(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as BWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();

        _next = GetNextPos();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        MoveNextPos();

        if (_windUpDoll._distance <= 0.1f)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
    }

    private void MoveNextPos()
    {
        Vector3 dir = (_next - _windUpDoll.transform.position).normalized;

        if ((_next - _windUpDoll.transform.position).magnitude <= 0.1f)
        {
            _windUpDoll.MoveCompo.StopImmediately();
            _next = GetNextPos();
        }

        _windUpDoll.RigidCompo.velocity = dir * _windUpDoll.
            EnemyStat.MoveSpeed * Time.deltaTime;
    }

    private Vector3 GetNextPos()
    {
        Vector3 radius = new Vector3(
                _windUpDoll.startPos.x + _windUpDoll.moveRadius,
                _windUpDoll.startPos.y,
                _windUpDoll.startPos.x + _windUpDoll.moveRadius);

        Vector3 result = new Vector3(
            Random.Range(radius.x, -radius.x), 
            _windUpDoll.startPos.y, 
            Random.Range(radius.z, -radius.z));

        if (_prev != null && (_prev - result).magnitude < 3)
        {
            return GetNextPos();
        }

        return result;
    }
}
