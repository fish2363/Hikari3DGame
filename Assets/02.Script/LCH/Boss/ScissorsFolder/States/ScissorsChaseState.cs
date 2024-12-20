using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsChaseState : EnemyState<BossState>
{
    private Scissors _scissors;
    int timer = 0;
    public ScissorsChaseState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("���󰡱�");
        timer = Random.Range(4, 7);
        _scissors.StartCoroutine(ChangeWaitState(timer));
        _scissors.IsPhaseEnd = false;
    }

    private IEnumerator ChangeWaitState(int timer)
    {
        yield return new WaitForSeconds(timer);
        _scissors.BossStateMachine.ChangeState(BossState.Wait);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector3 direction = _scissors.player.transform.position - _scissors.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _scissors.transform.rotation = lookRotation;
        }
        _scissors.targetDir = _scissors.player.transform.position - _scissors.transform.position;
        _scissors.RigidCompo.velocity =  _scissors.targetDir.normalized * _scissors.EnemyStat.ChasingSpeed;
    }

    public override void Exit()
    {
        base.Exit();
        timer = 0;
    }
}
