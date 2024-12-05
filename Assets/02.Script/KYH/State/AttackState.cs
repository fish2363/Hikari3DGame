using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State, IAttackable
{
    private Player _player;

    
    public AttackState(Player player) : base(player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        Attack();
    }

    private void Attack()
    {
        _player.isAttack = false;
        _player.animator.SetBool("Attack", true);
        _player.RigidCompo.velocity = Vector3.zero;
     


        _player.StartCoroutine(ChangeIdle());
    }

    IEnumerator ChangeIdle()
    { 
        RaycastHit[] hit = Physics.RaycastAll(_player.RayTransform.position, _player.transform.forward, 3, _player.whatIsEnemy);

        foreach(RaycastHit hittor in hit)
        {
            hittor.transform.TryGetComponent(out IAttackable attackIner);

            attackIner.HitEnemy(_player.currentWeaponData.weaponDamage, 3);
        }

        yield return new WaitForSeconds(_player.currentWeaponData.weaponAttackCoolTime);
        _player.isAttack = true;
        _player.animator.SetBool("Attack", false);
        _player.ChangeState(StateEnum.Idle);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void Exit()
    {
        _player.animator.SetFloat("Velocity",0);
        base.Exit();
    }

    public void Attack(Player agent, LayerMask hittable, Vector3 direction)
    {
       
    }

    public void HitEnemy(float damage, float knockbackPower)
    {
        
    }
}