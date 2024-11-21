using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/MeleeWeapon")]
public class WeaponMelee : WeaponData
{
    public float attackRange = 2f;

    public override void PerformAttack(Player agent, LayerMask hittable, Vector3 direction)
    {
        // 공격 로직 작성
    }
}
