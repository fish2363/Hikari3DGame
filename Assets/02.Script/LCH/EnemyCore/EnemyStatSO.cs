using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("SO/Enemy/Stat"))]
public class EnemyStatSO : ScriptableObject
{
	[Header("AttackSetting")]
	public float AttackRadius;
	public float WallRadius;
	public float AttackPoawer;
	public float KnobackPower;
	public float AttackDealy;
	public float ContactAttaackRadius;

	[Header("EnemySetting")]
	public float HP;
	public float MoveSpeed;
}
