using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttuGiWalk : EnemyState<EnemyStatEnum>
{
    private OttuGi _ottugi;

    public OttuGiWalk(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _ottugi = _enemy.GetComponent<OttuGi>();

        
        Debug.Log("나도 왔다");
    }

    public override void UpdateState()
    {
        _enemy.MoveCompo.playerPos = _enemy.player.transform;


        _enemy.range = Vector3.Distance(_enemy.MoveCompo.playerPos.position, _enemy.transform.position);

        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.player.transform.position, _enemy.EnemyStat.ChasingSpeed * Time.deltaTime);
   

        Vector3 direction = _enemy.player.transform.position - _enemy.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _enemy.transform.rotation = lookRotation;
        }

        if (_enemy.Hp <= 0)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Skill);
        }

        if (_enemy.range <= _enemy.EnemyStat.AttackRadius && _ottugi._isSkillExit)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
