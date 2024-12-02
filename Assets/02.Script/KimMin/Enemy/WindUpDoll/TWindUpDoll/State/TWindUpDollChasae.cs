using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TWindUpDollChase : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;

    public Transform target;    // 부채꼴에 포함되는지 판별할 타겟
    public float angleRange = 30f;
    public float radius = 3f;

    Color _blue = new Color(0f, 0f, 1f, 0.2f);
    Color _red = new Color(1f, 0f, 0f, 0.2f);

    bool isCollision = false;

    private Vector3 interV;

    public TWindUpDollChase(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
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

        if (_windUpDoll._distance > _windUpDoll.EnemyStat.AttackRadius)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
    }

    private void ChaseTarget()
    {
        Vector3 moveDir = (_windUpDoll.player.transform.position - _windUpDoll.transform.position).normalized;
        moveDir.y = 0;

        _windUpDoll.RigidCompo.velocity = moveDir * _enemy.EnemyStat.MoveSpeed * 2;
    }

    private void CheckSight()
    {
        if (target == null) return;

        interV = target.position - _windUpDoll.transform.position;

        if (interV.magnitude <= radius)
        {
            float dot = Vector3.Dot(interV.normalized, _windUpDoll.transform.forward);
            float theta = Mathf.Acos(dot);
            float degree = Mathf.Rad2Deg * theta;

            if (degree <= angleRange / 2f)
            {
                Debug.Log("시야 들어옴");
            }
            else
            {
                Debug.Log("시야 나감");
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (interV == null) return;
        //Debug.DrawRay(_windUpDoll.transform.position, new Vector3(0, 0, 0), Color.red);

        Handles.color = isCollision ? _red : _blue;
        // DrawSolidArc(시작점, 노멀벡터(법선벡터), 그려줄 방향 벡터, 각도, 반지름)
        Handles.DrawSolidArc(_windUpDoll.transform.position, Vector3.up, _windUpDoll.transform.forward, angleRange / 2, radius);
        Handles.DrawSolidArc(_windUpDoll.transform.position, Vector3.up, _windUpDoll.transform.forward, -angleRange / 2, radius);
    }
}