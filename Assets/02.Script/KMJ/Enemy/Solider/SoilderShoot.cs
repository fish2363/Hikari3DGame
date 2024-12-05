using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoilderShoot : EnemyState<EnemyStatEnum>
{
    private Soilder _soilder;
    private SoilderObject[] soilderObject;

    public SoilderShoot(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _soilder = enemy as Soilder;
    }

    public override void Enter()
    {
        soilderObject = _enemy.GetComponentsInChildren<SoilderObject>();
        base.Enter();
        soilderObject.ToList().ForEach(t => t.Attack());
    }

    public override void UpdateState()
    {
        base.UpdateState();

       
        if(_soilder._isMove)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
        if (_soilder.Hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
