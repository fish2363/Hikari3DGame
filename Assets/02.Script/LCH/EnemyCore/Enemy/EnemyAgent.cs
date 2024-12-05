using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyAgent : MonoBehaviour
{
    private float hp;

    public float Hp
    {
        get => hp;

        set
        {
            hp = value;

            if (hp < 0)
            {
                hp = 0;
                EnemyDie();
            }
        }
    }

    public EnemyStatSO EnemyStat;

    [field: SerializeField] public LayerMask whatIsPlayer;
    [field : SerializeField] public float range { get; set; }
	public EnemyMovement MoveCompo { get; protected set; }
	public Animator AnimCompo { get; protected set; } //Visual안만들면 터짐~
    public Rigidbody RigidCompo { get; protected set; }

    [HideInInspector] public Vector3 targetDir;

    public Player player;

    protected virtual void Awake()
    {
        hp = EnemyStat.HP;
        MoveCompo = GetComponent<EnemyMovement>();
        AnimCompo = GetComponentInChildren<Animator>();
        RigidCompo = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    protected abstract void EnemyDie();
    
}
