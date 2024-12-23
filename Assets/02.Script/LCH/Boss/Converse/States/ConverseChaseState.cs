using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverseChaseState : EntityState
{
    private Converse _converse;
    int timer = 0;

    public ConverseChaseState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _converse = entity as Converse;
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
        _converse.ChangeState(BossState.Wait);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector3 direction = _converse.player.transform.position - _converse.transform.position;

        direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();
            Debug.Log(direction.x+"xxx");
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _converse.transform.rotation = lookRotation;
        }
        _converse.targetDir = _converse.player.transform.position - _converse.transform.position;
        _converse.RigidCompo.velocity = _converse.targetDir.normalized * _converse.EnemyStat.ChasingSpeed;
        Debug.Log(_converse.RigidCompo.velocity+ "vvvvvvv");

    }

    public override void Exit()
    {
        base.Exit();
        timer = 0;
    }
}
