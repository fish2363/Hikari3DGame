using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverseChaseState : EnemyState<BossState>
{
    private Converse _converse;
    int timer = 0;

    public ConverseChaseState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _converse = enemy as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        timer = Random.Range(4, 7);
        _converse.StartCoroutine(ChangeWaitState(timer));
        _converse.IsPhaseEnd = false;
    }

    private IEnumerator ChangeWaitState(int timer)
    {
        yield return new WaitForSeconds(timer);
        _converse.BossStateMachine.ChangeState(BossState.Wait);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _converse.targetDir = _converse.player.transform.position - _converse.transform.position;
        _converse.RigidCompo.velocity = _converse.targetDir.normalized * _converse.EnemyStat.ChasingSpeed;
    }

    public override void Exit()
    {
        base.Exit();
        timer = 0;
    }
}
