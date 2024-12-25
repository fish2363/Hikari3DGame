using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ami.BroAudio;

public class ScissorsChaseState : EntityState
{
    private Scissors _scissors;
    int timer = 0;

    public ScissorsChaseState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;
    }

    public override void Enter()
    {
        base.Enter();
        timer = Random.Range(4, 7);
        _scissors.StartCoroutine(ChangeWaitState(timer));
        _scissors.IsPhaseEnd = false;
    }

    private IEnumerator ChangeWaitState(int timer)
    {
        yield return new WaitForSeconds(timer);
        if (!_scissors.IsDead)
        {
            _scissors.ChangeState(BossState.Wait);
        }
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
    }
}
