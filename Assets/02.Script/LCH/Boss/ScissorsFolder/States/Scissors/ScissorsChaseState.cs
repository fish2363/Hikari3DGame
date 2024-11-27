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
        int timer = Random.Range(4, 7);
        _scissors.StartCoroutine(ChangeWaitState(timer));
    }

    private IEnumerator ChangeWaitState(int timer)
    {
        yield return new WaitForSeconds(timer);
        _scissors.BossStateMachine.ChangeState(BossState.Wait);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _scissors.targetDir = _scissors.player.transform.position - _scissors.transform.position;
        _scissors.RigidCompo.velocity =  _scissors.targetDir.normalized * _scissors.EnemyStat.MoveSpeed;
    } 
}
