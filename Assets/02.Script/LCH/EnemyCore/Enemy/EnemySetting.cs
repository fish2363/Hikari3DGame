using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour 
{
    public float hp;

	public EnemyStatSO _enemyStat;

    [field: SerializeField] public LayerMask whatIsPlayer;
    [field : SerializeField] public float range { get; set; }
	public EnemyMovement MoveCompo { get; protected set; }
	public Animator AnimCompo { get; protected set; } //Visual�ȸ���� ����~

    protected Player _player;

    protected virtual void Awake()
    {
        hp = _enemyStat.HP;
        MoveCompo = GetComponent<EnemyMovement>();
        AnimCompo = GetComponentInChildren<Animator>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        
    }

    
}
