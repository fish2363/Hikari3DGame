using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpiderMove : EnemyState<EnemyStatEnum>
{
    private Spider _spider;
    private RaycastHit hit;
    private Vector3 _nextPos;

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

        if (_spider.distance < _spider.EnemyStat.AttackRadius * 4)
        {
            _spider.stateMachine.ChangeState(EnemyStatEnum.Chase);
        }
    }

    private void MoveNextPos()
    {
        Vector3 dir = (_nextPos - _spider.transform.position).normalized;

        if ((_nextPos - _spider.transform.position).magnitude <= 2f)
        {
            _spider.MoveCompo.StopImmediately();
            _nextPos = _spider.GetNextPos();
        }
<<<<<<< HEAD
=======

>>>>>>> parent of 6305e7d (Merge branch 'Base' into KDY)
        _spider.RigidCompo.velocity = dir * _spider.EnemyStat.ProwlSpeed;
    }
}
