using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarAttack : EnemyState<EnemyStatEnum>
{
    public RcCarAttack(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }


    public override void Enter()
    {
        Debug.Log("�� ����");
        base.Enter();

        if(Physics.Raycast(_enemy.transform.position,_enemy.transform.forward,_enemy.whatIsPlayer))
        {
            Debug.Log("�� ����");
        }
    }

    public override void UpdateState()
    {
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
