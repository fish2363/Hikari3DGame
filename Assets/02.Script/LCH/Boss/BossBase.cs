using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossBase : MonoBehaviour
{
    public UnityEvent OnphaseEvent;

    [SerializeField] private EnemyStatSO _enemystat;
}
