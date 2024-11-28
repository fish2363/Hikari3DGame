using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderShoot : EnemyState<EnemyStatEnum>
{
    private Soilder _soilder;
    public SoilderShoot(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _soilder = enemy as Soilder;
    }

    public override void Enter()
    {
        base.Enter();
        _soilder.Attack();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Debug.Log("¶öÁö ¤©¤·");
        if(_soilder._isMove)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
        if (_soilder.hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
