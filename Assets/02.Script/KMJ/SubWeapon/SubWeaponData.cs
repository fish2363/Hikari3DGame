using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "SubWeaponData")]
public class SubWeaponData : ScriptableObject
{
    public string weaponName;

    public Mesh weaponModel;

    public float attacDamage;

    public float attacRange;

    public AudioClip weaponSwingSound;

    public Material weaponMaterial;

    public RuntimeAnimatorController animatorControlloer;
}
