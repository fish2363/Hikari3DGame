using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour 
{
	[SerializeField] private EnemyStatSO _enemyStat;

	public EnemyMovement MoveCompo { get; protected set; }
	public Animator AnimCompo { get; protected set; } //Visual안만들면 터짐~

    protected virtual void Awake()
    {
        MoveCompo = GetComponent<EnemyMovement>();
        AnimCompo = GetComponentInChildren<Animator>();
    }

    public Collider[] GetPlayerRange(Transform trm, float detectRadius, LayerMask whatIsPlayer)
    {
        Collider[] colliders = Physics.OverlapSphere(trm.position, detectRadius, whatIsPlayer);

        return colliders ??= null;
    }
}
