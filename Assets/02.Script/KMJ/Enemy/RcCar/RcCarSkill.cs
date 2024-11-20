using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarSkill : EnemyState<EnemyStatEnum>
{
    private GameObject _player;

    public RcCarSkill(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        _player = GameObject.FindWithTag("Player");

        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _player.transform.position, 20 * Time.deltaTime);

       bool ishit = Physics.Raycast(_enemy.transform.position,_enemy.transform.forward, 2, _enemy.whatIsPlayer);
        
        if(ishit == true)
        {
            
        }
    }

    public override void UpdateState()
    {
        _stateMachine.ChangeState(EnemyStatEnum.Walk);
            

        if (_enemy.hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        base.Exit();
    }

}
