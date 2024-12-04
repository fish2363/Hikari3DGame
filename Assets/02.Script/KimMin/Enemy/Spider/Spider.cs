using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spider : Enemy
{
    [HideInInspector] public Vector3 interV = Vector3.zero;
    [HideInInspector] public bool isWall = false;
    [HideInInspector] public bool isCollision = false;

    public float maxHeight = 10f;
    public float angleRange = 30f;
    public float radius = 3f;
    public float moveRadius = 5f;

    public Vector3 startPos;

    public LayerMask whatIsWall;

    public bool canAttack = false;

    private readonly float _gravity = -9.81f;
    private Vector3 _gravityDir;
    private Vector3 _prev;

    private Color _blue = new Color(0f, 0f, 1f, 0.2f);
    private Color _red = new Color(1f, 0f, 0f, 0.2f);

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new SpiderIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new SpiderMove(this, stateMachine, "Move"));
        stateMachine.AddState(EnemyStatEnum.Chase, new SpiderChase(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyStatEnum.Attack, new SpiderAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Skill, new SpiderSkill(this, stateMachine, "Skill"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
        canAttack = false;
    }

    private void Update()
    {
        Debug.Log(stateMachine.CurrentState);
        stateMachine.CurrentState.UpdateState();
        FlipEnemy();

    }

    private void FixedUpdate()
    {
        HandleGravity();
    }

    private void HandleGravity()
    {
        _gravityDir = transform.up * _gravity;

        Debug.Log(_gravityDir);
        RigidCompo.velocity += _gravityDir;
    }

    private void FlipEnemy()
    {
        if (!isWall)
            transform.rotation = Quaternion.LookRotation(new Vector3(RigidCompo.velocity.x, 0, RigidCompo.velocity.z));
    }

    public Vector3 GetNextPos()
    {
        Vector3 radius = new Vector3(startPos.x + moveRadius, startPos.y, startPos.z + moveRadius);

        Vector3 result = new Vector3(
            Random.Range(radius.x, -radius.x), startPos.y,
            Random.Range(radius.z, -radius.z));


        if (_prev != null && (_prev - result).magnitude < 5)
        {
            return GetNextPos();
        }

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, EnemyStat.AttackRadius);

        if (interV == null) return;
         Debug.DrawRay(transform.position, new Vector3(0, 0, 0), Color.red);

        Handles.color = isCollision ? _red : _blue;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, radius);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, radius);
    }

    protected override void AnimEndTrigger()
    {

    }

    protected override void EnemyDie()
    {

    }
}
