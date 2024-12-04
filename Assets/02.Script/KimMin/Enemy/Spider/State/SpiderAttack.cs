using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : EnemyState<EnemyStatEnum>
{
    private Spider _spider;
    private float _currentTime;

    public SpiderAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _spider = enemy as Spider;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _currentTime += Time.deltaTime;

        if (_currentTime > _spider.EnemyStat.AttackDelay)
        {
            _spider.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }
}
