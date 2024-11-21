using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData")]
public abstract class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponModel;
    public int weaponDamage;
    public AudioClip weaponSwingSound;

    public abstract void PerformAttack(Player agent, LayerMask hittable, Vector3 direction);
}
