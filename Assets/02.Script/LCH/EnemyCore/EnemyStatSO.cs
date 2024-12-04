using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("SO/Enemy/Stat"))]
public class EnemyStatSO : ScriptableObject
{
	[Header("AttackSetting")]
	public float AttackRadius;
	public float WallRadius;
	public float KnockbackPower;
	public float AttackDelay;
	public float ContactAttackRadius;
    public int MinAttackDamage;
    public int MaxAttackDamage;

    [Header("EnemySetting")]
	public string Name;
	public float HP;
	public float MoveSpeed;
}
