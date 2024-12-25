using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Mesh weaponModel;
    public int weaponDamage;
    public float weaponAttackCoolTime;
    public Sprite weaponSprite;
    public AudioClip weaponSwingSound;
    public Material weaponMaterial;
    public RuntimeAnimatorController animatorControlloer;
}
 
