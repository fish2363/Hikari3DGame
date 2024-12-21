using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsAttackCompo : MonoBehaviour
{

    private DamageCast _damgeCast;

    private void Awake()
    {
        _damgeCast = GetComponentInChildren<DamageCast>();
    }

    public void Attack()
    {
        _damgeCast.CastDamage();
    }
}
