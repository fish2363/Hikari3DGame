using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponModel;
    public int weaponDamage;
    public float weaponAttackCoolTime;
    public AudioClip weaponSwingSound;
}

interface IAttack
{
    public void Attack(Player agent, LayerMask hittable, Vector3 direction);
}
 
