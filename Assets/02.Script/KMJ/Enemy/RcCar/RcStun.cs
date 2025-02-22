using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcStun : EnemyState<EnemyStatEnum>
{
    private bool _isStun;
    private Enemy enemy;
    public RcStun(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        enemy = _enemy.GetComponent<Enemy>();
        base.Enter();
        enemy.StartCoroutine(Stun());
        enemy.RigidCompo.velocity = Vector3.zero;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_isStun)
            enemy.stateMachine.ChangeState(EnemyStatEnum.Walk);
    }

    IEnumerator Stun()
    {
        _isStun = false;

        enemy.StunEffect();
        yield return new WaitForSeconds(1f);

        _isStun = true;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
