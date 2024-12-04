using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State, IAttackable
{
    private Player _player;
    public AttackState(Player player) : base(player)
    {
        _player = player;
    }

    public override void Enter()
    {

        _player.RigidCompo.velocity = Vector3.zero;
        base.Enter();
        RaycastHit[] hit = Physics.RaycastAll(_player.transform.position, _player.transform.forward, 3, _player.whatIsEnemy);

        if (hit == null)
            _player.ChangeState(StateEnum.Idle);
        else
        {
            foreach (RaycastHit hittor in hit)
            {
                hittor.transform.TryGetComponent(out IAttackable attackIner);

                attackIner.HitEnemy(10,3);
                _player.ChangeState(StateEnum.Idle);
            }
        }
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public void Attack(Player agent, LayerMask hittable, Vector3 direction)
    {
       
    }

    public void HitEnemy(float damage, float knockbackPower)
    {
        
    }
}
