using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void Attack(Player agent, LayerMask hittable, Vector3 direction);

    public void HitEnemy(float damage, float knockbackPower);
}
