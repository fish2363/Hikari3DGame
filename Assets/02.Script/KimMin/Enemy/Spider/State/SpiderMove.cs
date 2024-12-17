using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpiderMove : EnemyState<EnemyStatEnum>
{
    private Spider _spider;
    private RaycastHit hit;

    public SpiderMove(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _spider = enemy as Spider;
    }

    public override void Enter()
    {
        base.Enter();
        _spider.StopImmediately();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        MoveNextPos();

        if (_spider.distance < _spider.detectRadius)
        {
            _spider.stateMachine.ChangeState(EnemyStatEnum.Chase);
        }
    }

    private void MoveNextPos()
    {
        Vector3 dir = (_spider.nextPos - _spider.transform.position).normalized;

        if ((_spider.nextPos - _spider.transform.position).magnitude <= 2f)
        {
            _spider.MoveCompo.StopImmediately();
            _spider.nextPos = _spider.GetNextPos();
        }
        _spider.RigidCompo.velocity = dir * _spider.EnemyStat.ProwlSpeed;
    }
}
