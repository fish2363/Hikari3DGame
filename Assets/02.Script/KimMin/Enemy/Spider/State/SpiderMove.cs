using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : EnemyState<EnemyStatEnum>
{
    private Spider _spider;
    private RaycastHit hit;

    public SpiderMove(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _spider = enemy as Spider;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        MoveForward();
        CheckWall();
    }

    private void MoveForward()
    {
        Vector3 moveDir = _spider.isWall ? Vector3.up : Vector3.forward;

        _spider.RigidCompo.velocity = moveDir * _spider.EnemyStat.MoveSpeed;

        if (_spider.transform.position.y >= _spider.maxHeight)
        {
            Debug.Log("∏ÿ√Á");
            _spider.stateMachine.ChangeState(EnemyStatEnum.Idle);
        }
    }

    private void CheckWall()
    {
        if (Physics.Raycast(_spider.transform.position, _spider.transform.forward, out hit, _spider.transform.localScale.x / 2, _spider.whatIsWall))
        {
            Debug.DrawRay(_spider.player.transform.position, hit.point, Color.red);

            if (!_spider.isWall) ChangeToWall();
        }
    }

    private void ChangeToWall()
    {
        _spider.isWall = true;
        _spider.transform.DORotate(new Vector3(-90, 0, 0), 0.5f);

        _spider.RigidCompo.useGravity = false;
    }
}
