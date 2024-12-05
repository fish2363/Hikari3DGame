using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarDie : EnemyState<EnemyStatEnum>
{
    public RcCarDie(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        _enemy.transform.gameObject.SetActive(false);
    }
}
