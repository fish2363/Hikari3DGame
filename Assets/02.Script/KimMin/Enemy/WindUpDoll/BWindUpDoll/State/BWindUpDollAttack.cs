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

        Vector3 spawnPos = _windUpDoll.transform.position;
        spawnPos.y += 1;

        GameObject.Instantiate(_windUpDoll.explosionSmokeEffect, spawnPos, Quaternion.identity);

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
        Vector3 spawnPos = _windUpDoll.transform.position;
        GameObject.Instantiate(_windUpDoll.explostionEffect1, spawnPos, Quaternion.identity);
        spawnPos.y += 2;
        GameObject.Instantiate(_windUpDoll.explostionEffect2, spawnPos, Quaternion.identity);
        _windUpDoll.gameObject.SetActive(false);
    }
}
