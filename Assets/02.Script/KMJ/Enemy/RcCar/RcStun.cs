using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcStun : EnemyState<EnemyStatEnum>
{
    private bool _isStun;
    private RcCar _rcCar;
    public RcStun(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _rcCar = enemy as RcCar;
    }

    public override void Enter()
    {
        base.Enter();
        _rcCar.StartCoroutine(Stun());
        _rcCar.RigidCompo.velocity = Vector3.zero;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_isStun)
            _rcCar.stateMachine.ChangeState(EnemyStatEnum.Walk);
    }

    IEnumerator Stun()
    {
        _isStun = false;

        _rcCar.StunEffect();
        yield return new WaitForSeconds(1f);

        _isStun = true;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
