using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("SO/Enemy/Stat"))]
public class EnemyStatSO : ScriptableObject
{
	[Header("AttackSetting")]
	public float AttackRadius; //공격 범위
	public float WallRadius;
	public float KnockbackPower; //넉백 파워
	public float AttackDelay; //공격 쿨타임
	public float ContactAttackRadius; //접촉 공격력
    public int MinAttackDamage; //최소 공격력
    public int MaxAttackDamage; //최대 공격력

    [Header("EnemySetting")]
	public string Name; //이름
	public string Key; //키
	public float HP; //체력
	public float ProwlSpeed; //배회 속도
	public float ChasingSpeed; //추격 속도
}
