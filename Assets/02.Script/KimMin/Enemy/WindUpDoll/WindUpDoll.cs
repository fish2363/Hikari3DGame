using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using Ami.BroAudio;

public class WindUpDoll : Enemy, IDamageable
{
    [HideInInspector] public float _distance;
    [HideInInspector] public Vector3 nextPos;
    [HideInInspector] public Vector3 moveDir;

    [field: SerializeField] public SoundID WindUp { get; set; }

    public LayerMask whatisPlayer;
    public Vector3 startPos;
    public float moveRadius;

    private Vector3 _prev = Vector3.zero;
    private Vector3 _radius;

    private void OnValidate()
    {
        startPos = transform.position;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Update()
    {
        _distance = (player.transform.position - transform.position).magnitude;
    }

    public Vector3 GetNextPos()
    {
        _radius = new Vector3(moveRadius, startPos.y, moveRadius) / 2;

        float x = Random.Range(_radius.x, -_radius.x);
        float z = Random.Range(_radius.z, -_radius.z);

        nextPos = startPos + new Vector3(x , transform.localScale.y, z);

        if (_prev != null && (_prev - nextPos).magnitude < 3)
        {
            return GetNextPos();
        }

        return nextPos;
    }

    public void FlipEnemy()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(RigidCompo.velocity.x, 0, RigidCompo.velocity.z));
    }

    protected override void AnimEndTrigger()
    {

    }

    protected override void EnemyDie()
    {
        stateMachine.ChangeState(EnemyStatEnum.Dead);
    }


    public void Attack(Player agent, LayerMask hittable, Vector3 direction)
    {

    }

    public void ApplyDamage(float damage)
    {
        Hp -= damage;
        var item = Instantiate(getDamageEffect);
        item.SetPositionAndPlay(transform.position, transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out IDamageable damageable))
        {
            int damage = Mathf.RoundToInt(Random.Range(EnemyStat.MinAttackDamage, EnemyStat.MaxAttackDamage));
            damageable.ApplyDamage(damage);
        }
    }
}
