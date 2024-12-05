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

    private Vector3 _prev;

    protected virtual void Update()
    {
        _distance = (player.transform.position - transform.position).magnitude;

        FlipEnemy();
    }

    public Vector3 GetNextPos()
    {
        Vector3 radius = new Vector3(startPos.x + moveRadius, startPos.y, startPos.z + moveRadius);

        float x = Random.Range(radius.x, -radius.x);
        float z = Random.Range(radius.z, -radius.z);

        Vector3 result = new Vector3(x, transform.localScale.y / 2, z);

        if (_prev != null && (_prev - result).magnitude < 5)
        {
            return GetNextPos();
        }

        return result;
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
        Hp -= damage;
    }

    public void Attack(Player agent, LayerMask hittable, Vector3 direction)
    {

    }
}
