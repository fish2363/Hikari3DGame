using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class WindUpDoll : Enemy,IAttackable
{
    [HideInInspector] public float _distance;
    [HideInInspector] public Vector3 nextPos;
    [HideInInspector] public Vector3 moveDir;

    public Vector3 startPos;
    public float moveRadius;

    private Vector3 _prev = Vector3.zero;
    private Vector3 _radius;

    protected override void Awake()
    {
        base.Awake();
        startPos = transform.position;
    }

    protected virtual void Update()
    {
        _distance = (player.transform.position - transform.position).magnitude;

        FlipEnemy();
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

    private void FlipEnemy()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(RigidCompo.velocity.x, 0, RigidCompo.velocity.z));
    }

    protected override void AnimEndTrigger()
    {

    }

    protected override void EnemyDie()
    {

    }

    public void HitEnemy(float damage, float knockbackPower)
    {

    }

    public void Attack(Player agent, LayerMask hittable, Vector3 direction)
    {

    }
}
