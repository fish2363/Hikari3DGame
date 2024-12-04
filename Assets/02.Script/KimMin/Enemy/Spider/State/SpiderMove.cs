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
        Vector3 moveDir;

        if (!_spider.isWall)
        {
            moveDir = Vector3.forward * _spider.EnemyStat.MoveSpeed;
        }
        else
        {
            moveDir = Vector3.up * _spider.EnemyStat.MoveSpeed;
        }

        _spider.RigidCompo.velocity = moveDir;

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
        Debug.Log("º®´À²¸Á®..");
        _spider.isWall = true;
        _spider.transform.DORotate(new Vector3(-90, 0, 0), 0.5f);

        _spider.RigidCompo.constraints = RigidbodyConstraints.FreezePositionX;
        _spider.RigidCompo.constraints = RigidbodyConstraints.FreezePositionY;
        _spider.RigidCompo.constraints = RigidbodyConstraints.FreezeRotationX;
        _spider.RigidCompo.useGravity = false;
    }
}
