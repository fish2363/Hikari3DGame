using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Numerics;

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
        _player.RigidCompo.velocity = UnityEngine.Vector3.zero;



        _player.StartCoroutine(ChangeIdle());
    }

    IEnumerator ChangeIdle()
    {
        yield return new WaitForSeconds(_player.currentWeaponData.weaponAttackCoolTime / 2);

        Collider[] hit = Physics.OverlapBox(_player.RayTransform.position, _player.size, _player.transform.rotation, _player.whatIsEnemy);

        foreach (Collider hittor in hit)
        {
            _player.playerCam.transform.DOShakePosition(0.4f, 0.2f, 10,90);

            hittor.transform.TryGetComponent(out IAttackable attackIner);

            attackIner.HitEnemy(_player.currentWeaponData.weaponDamage, 3);
        }

        yield return new WaitForSeconds(_player.currentWeaponData.weaponAttackCoolTime / 2);
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
        _player.animator.SetFloat("Velocity", 0);
        base.Exit();
    }

    public void Attack(Player agent, LayerMask hittable, UnityEngine.Vector3 direction)
    {

    }

    public void HitEnemy(float damage, float knockbackPower)
    {

    }
}