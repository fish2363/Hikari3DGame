using Ami.BroAudio;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSkill : EnemyState<EnemyStatEnum>
{
    private Spider _spider;
    private float _currentTime;

    public SpiderSkill(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _spider = enemy as Spider;  
    }

    public override void Enter()
    {
        base.Enter();

        JumpAttack();
        _currentTime = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _currentTime += Time.deltaTime;

        if (_currentTime >= _spider.skillCoolTime)
        {
            _spider.canAttack = true;
        }
    }

    private void JumpAttack()
    {
        _spider.canAttack = false;
        _spider.transform
            .DOJump(_spider.player.transform.position, 12f, 1, 1.5f)
            .InsertCallback(1f,() =>
            {
                BroAudio.Play(_spider.SpiderJump);
            })
            .OnComplete(() =>
            {
                _spider.stateMachine.ChangeState(EnemyStatEnum.Walk);
            });
    }
}   
