using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
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

    public override void UpdateState()
    {
        base.UpdateState();
        MoveNextPos();
    }

    private void MoveNextPos()
    {
        Vector3 dir = (_nextPos - _spider.transform.position).normalized;

        if ((_nextPos - _spider.transform.position).magnitude <= 2f)
        {
            _spider.MoveCompo.StopImmediately();
            _nextPos = _spider.GetNextPos();
        }

        _spider.RigidCompo.velocity = dir * _spider.EnemyStat.MoveSpeed;
    }

    /*    private void MoveForward()
        {
            Vector3 moveDir = _spider.isWall ? Vector3.up : Vector3.forward;

            _spider.RigidCompo.velocity = moveDir * _spider.EnemyStat.MoveSpeed;

            if (_spider.transform.position.y >= _spider.maxHeight)
            {
                _spider.stateMachine.ChangeState(EnemyStatEnum.Idle);
            }

            if ((_spider.player.transform.position - _spider.transform.position).magnitude
                < _spider.EnemyStat.AttackRadius * 3f)
            {
                _spider.stateMachine.ChangeState(EnemyStatEnum.Chase);
            }
        }*/

    /*    private void CheckWall()
        {
            if (Physics.Raycast(_spider.transform.position, _spider.transform.forward, out hit, _spider.transform.localScale.z / 2 + 0.1f, _spider.whatIsWall))
            {
                if (!_spider.isWall) ChangeToWall();
            }
        }*/

    private void ChangeToWall()
    {
        _spider.isWall = true;
        _spider.transform.DORotate(new Vector3(-90, 0, 0), 0.5f);

        _spider.RigidCompo.useGravity = false;
    }
}
