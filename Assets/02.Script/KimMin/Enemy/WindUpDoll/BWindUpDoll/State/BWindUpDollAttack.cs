using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    private BWindUpDoll _windUpDoll;

    private float _currrentTime;

    public BWindUpDollAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as BWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        _windUpDoll.MoveCompo.StopImmediately();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _currrentTime += Time.deltaTime;

        if (_currrentTime >= Mathf.PI)
        {
            Explostion();
        }
    }

    private void Explostion()
    {
        _windUpDoll.gameObject.SetActive(false);
        _windUpDoll.InstantiateObject(_windUpDoll.explostionEffect, _windUpDoll.transform.position);
    }
}
