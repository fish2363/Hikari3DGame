using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    private float _dashPower = 2f, _dashTime = 0.5f;

    private NWindUpDoll _windUpDoll;

    public NWindUpDollAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as NWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        HeadAttack();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float time = Time.time;
        if(time  > _dashTime)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }

    private void HeadAttack()
    {
        Vector3 direction = (_windUpDoll.player.transform.position - _windUpDoll.transform.position).normalized;
        direction.y = 0;

        _windUpDoll.RigidCompo.AddForce(direction * _dashPower, ForceMode.Impulse);
    }
}
