using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BossBase : MonoBehaviour
{
    public UnityEvent OnphaseEvent;

    [field:SerializeField] public EnemyStatSO Enemystat { get; private set; }

    protected bool isPhaseEnd;

    public Animator AnimatorCompo { get; private set; }
    public Rigidbody RbCompo { get; set; }

    protected virtual void Awake()
    {
        RbCompo = GetComponent<Rigidbody>();
        AnimatorCompo = GetComponentInChildren<Animator>();
    }

    public abstract void BossyDie();

    public abstract void BossAttack();
}
