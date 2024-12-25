using Ami.BroAudio;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    private readonly float _gravity = -9.81f;

    [HideInInspector] public Vector3 interV = Vector3.zero;
    [HideInInspector] public Vector3 _radius = Vector3.zero;
    [HideInInspector] public Vector3 nextPos;

    [HideInInspector] public bool isCollision = false;
    [HideInInspector] public bool isWall = false;
    [HideInInspector] public bool canAttack = true;

    [HideInInspector] public float detectRadius => EnemyStat.AttackRadius * 4f;
    [HideInInspector] public float distance => (player.transform.position - transform.position).magnitude;

    [field: SerializeField] public SoundID SpiderJump { get; set; }
    [field: SerializeField] public SoundID SpiderWalk { get; set; }

    [Header("Setting")]
    public float maxHeight = 10f;
    public float angleRange = 30f;
    public float radius = 3f;
    public float moveRadius = 5f;
    public float skillCoolTime = 8f;

    public Vector3 startPos;
    public LayerMask whatIsWall;

    private Vector3 _gravityDir;
    private Vector3 _prev;

    private Color _blue = new Color(0f, 0f, 1f, 0.2f);
    private Color _red = new Color(1f, 0f, 0f, 0.2f);

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Walk, new SpiderMove(this, stateMachine, "Move"));
        stateMachine.AddState(EnemyStatEnum.Chase, new SpiderChase(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyStatEnum.Skill, new SpiderSkill(this, stateMachine, "Attack"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);

        startPos = transform.position;
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

        RigidCompo.velocity += _gravityDir;
    }

    private void FlipEnemy()
    {
        if (!isWall)
            transform.rotation = Quaternion.LookRotation(new Vector3(RigidCompo.velocity.x, 0, RigidCompo.velocity.z));
    }

    public Vector3 GetNextPos()
    {
        _radius = new Vector3(moveRadius, startPos.y, moveRadius) / 2;

        float x = Random.Range(_radius.x, -_radius.x);
        float z = Random.Range(_radius.z, -_radius.z);

        nextPos = startPos + new Vector3(x, transform.localScale.y, z);

        if (_prev != null && (_prev - nextPos).magnitude < 3)
        {
            return GetNextPos();
        }

        return nextPos;
    }

    protected override void AnimEndTrigger()
    {

    }

    protected override void EnemyDie()
    {

    }

    public void ApplyDamage(float damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            EnemyDie();
            return;
        }

        var item = Instantiate(getDamageEffect);
        item.SetPositionAndPlay(transform.position, transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, EnemyStat.AttackRadius);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.DrawWireSphere(transform.position, moveRadius);
        Gizmos.DrawLine(transform.position, nextPos);

        if (interV == null) return;
        Debug.DrawRay(transform.position, new Vector3(0, 0, 0), Color.red);

        Handles.color = isCollision ? _red : _blue;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, radius);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, radius);
    }
}
