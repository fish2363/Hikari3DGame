using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    private float _dashPower = 10f, _dashTime = 0.5f;

    private WindUpDoll _windUpDoll;

    public NWindUpDollAttack(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as WindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        HeadAttack();
    }

    private void HeadAttack()
    {
        Vector3 direction = (_windUpDoll.player.transform.position - _windUpDoll.transform.position).normalized;
        direction.y = 0;

        _windUpDoll.RIgidCompo.AddForce(direction * _dashPower, ForceMode.Impulse);
    }
}
