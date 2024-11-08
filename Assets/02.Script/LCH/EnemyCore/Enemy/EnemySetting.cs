using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour 
{
	public EnemyStatSO _enemyStat;

    [field: SerializeField] public LayerMask whatIsPlayer;
    [field : SerializeField] public float range { get; set; }
	public EnemyMovement MoveCompo { get; protected set; }
	public Animator AnimCompo { get; protected set; } //Visual안만들면 터짐~

    protected virtual void Awake()
    {
        MoveCompo = GetComponent<EnemyMovement>();
        AnimCompo = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        range = Vector3.Distance(MoveCompo.playerPos.position, transform.position);
    }
}
