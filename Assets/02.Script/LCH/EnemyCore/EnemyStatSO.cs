using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("SO/Enemy/Stat"))]
public class EnemyStatSO : ScriptableObject
{
	[Header("AttackSetting")]
	public float AttackRadius; //���� ����
	public float WallRadius;
	public float KnockbackPower; //�˹� �Ŀ�
	public float AttackDelay; //���� ��Ÿ��
	public float ContactAttackRadius; //���� ���ݷ�
    public int MinAttackDamage; //�ּ� ���ݷ�
    public int MaxAttackDamage; //�ִ� ���ݷ�

    [Header("EnemySetting")]
	public string Name; //�̸�
	public string Key; //Ű
	public float HP; //ü��
	public float ProwlSpeed; //��ȸ �ӵ�
	public float ChasingSpeed; //�߰� �ӵ�
}
