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
        _nextPos = _spider.GetNextPos();
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
        if ((_nextPos - _spider.transform.position).magnitude <= 2f)
        {
            _spider.MoveCompo.StopImmediately();
            _nextPos = _spider.GetNextPos();
        }
        _spider.RigidCompo.velocity = _nextPos * _spider.EnemyStat.ProwlSpeed;
    }
}
