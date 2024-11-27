using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsChaseState : EnemyState<BossState>
{
    private Scissors _scissors;
    public ScissorsChaseState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _scissors.targetDir = _scissors.player.transform.position - _scissors.transform.position;
        _scissors.RigidCompo.velocity =  _scissors.targetDir.normalized * _scissors.EnemyStat.MoveSpeed;
    } 
}
