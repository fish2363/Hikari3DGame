using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    private float _dashPower = 25f, _currentTime, _dashTime = 0.5f;

    private NWindUpDoll _windUpDoll;

    public NWindUpDollAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as NWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        HeadAttack();

        _currentTime = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _currentTime += Time.deltaTime;
        if(_currentTime > _dashTime)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }

    public override void Exit()
    {
        base.Exit();
        StopImmediately(_windUpDoll);
    }

    private void HeadAttack()
    {
        Vector3 direction = (_windUpDoll.player.transform.position - _windUpDoll.transform.position).normalized;
        direction.y = 0;

        _windUpDoll.RigidCompo.AddForce(direction * _dashPower, ForceMode.Impulse);
        _windUpDoll.StartCoroutine(NWindUpDollDashRoutine());
    }

    private IEnumerator NWindUpDollDashRoutine()
    {
        _windUpDoll.canAttack = false;
        yield return new WaitForSeconds(_enemy.EnemyStat.AttackDelay);
        _windUpDoll.canAttack = true;
    }
}
