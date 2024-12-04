using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TWindUpDoll : WindUpDoll
{
    [HideInInspector] public Vector3 interV = Vector3.zero;
    [HideInInspector] public bool isCollision = false;

    public float angleRange = 30f;
    public float radius = 3f;

    Color _blue = new Color(0f, 0f, 1f, 0.2f);
    Color _red = new Color(1f, 0f, 0f, 0.2f);

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Walk, new TWindUpDollMove(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Chase, new TWindUpDollChase(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyStatEnum.Attack, new TWindUpDollAttack(this, stateMachine, "Attack"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
    }

    protected override void Update()
    {
        base.Update();
        Debug.Log(stateMachine.CurrentState);
        stateMachine.CurrentState.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, EnemyStat.AttackRadius);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, EnemyStat.AttackRadius * 2.5f);

        if (interV == null) return;
            Debug.DrawRay(transform.position, new Vector3(0, 0, 0), Color.red);

        Handles.color = isCollision ? _red : _blue; 
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, radius);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, radius);
    }
}
