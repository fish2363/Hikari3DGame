using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttugiChildWalkk : EnemyState<EnemyStatEnum>
{

    private OttugiChild _ottugi;

    public OttugiChildWalkk(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _ottugi = enemy as OttugiChild;
    }

    public override void Enter()
    {
        base.Enter();
        _ottugi = _enemy.GetComponent<OttugiChild>();


        Debug.Log("나도 왔다");
        base.Enter();
    }

    public override void UpdateState()
    {
        _enemy.MoveCompo.playerPos = GameObject.FindWithTag("Player").transform;

        _enemy.range = Vector3.Distance(_enemy.MoveCompo.playerPos.position, _enemy.transform.position);
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.player.transform.position, _enemy.EnemyStat.MoveSpeed * Time.deltaTime);

        Vector3 direction = _enemy.player.transform.position - _enemy.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _enemy.transform.rotation = lookRotation;
        }
        if (_enemy.hp <= 0)
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
