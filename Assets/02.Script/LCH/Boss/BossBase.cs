using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BossBase : MonoBehaviour
{
    public UnityEvent OnphaseEvent;

    public bool phase2 = false;

    [field:SerializeField] public EnemyStatSO Enemystat { get; private set; }

    protected bool isPhaseEnd;

    public Animator AnimatorCompo { get; private set; }

    protected virtual void Awake()
    {
        AnimatorCompo = GetComponentInChildren<Animator>();
    }

    public abstract void BossyDie();

    public abstract void BossAttack();
}
