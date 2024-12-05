using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderChase : EnemyState<EnemyStatEnum>
{
    private Spider _spider;
    private float _time;

    public SpiderChase(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _spider = enemy as Spider;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        ChaseTarget();
        CheckSight();

        if (_spider.isCollision)
        {
            _spider.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
        if (_spider.distance >= _spider.EnemyStat.AttackRadius * 4f)
        {
            _spider.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }

        _time += Time.deltaTime;

        if (_time >= 1f)
        {
            _time = 0;
            int rand = Random.Range(0, 5);

            if (rand == 1)
                _spider.stateMachine.ChangeState(EnemyStatEnum.Skill);
        }
    }

    private void ChaseTarget()
    {
        Vector3 moveDir = (_spider.player.transform.position - _spider.transform.position).normalized;
        moveDir.y = 0;

        _spider.RigidCompo.velocity = moveDir * _enemy.EnemyStat.ChasingSpeed;
    }

    private void CheckSight()
    {
        if (_spider.player == null) return;

        _spider.interV = _spider.player.transform.position - _spider.transform.position;

        if (_spider.interV.magnitude <= _spider.radius)
        {
            float dot = Vector3.Dot(_spider.interV.normalized, _spider.transform.forward);
            float theta = Mathf.Acos(dot);
            float degree = Mathf.Rad2Deg * theta;

            _spider.isCollision = degree <= _spider.angleRange / 2f ? true : false;
        }
    }
}
