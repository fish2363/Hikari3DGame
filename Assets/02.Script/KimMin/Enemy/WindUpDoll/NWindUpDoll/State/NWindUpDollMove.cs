using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollMove : EnemyState<EnemyStatEnum>
{
    private WindUpDoll _windUpDoll;

    public NWindUpDollMove(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as WindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Move();

        if(_windUpDoll._distance <  _windUpDoll._enemyStat.AttackRadius)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
    }

    private void Move()
    {
        Debug.Log("¹«ºù¸Ç");
        Vector3 moveDir = (_windUpDoll.player.transform.position - _windUpDoll.transform.position).normalized;
        moveDir.y = 0;

        _windUpDoll.RigidCompo.AddForce(moveDir * _enemy._enemyStat.MoveSpeed, ForceMode.Force);
    }
}
