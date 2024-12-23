using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AttackState : State
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

        

        if (_player.currentWeaponData.name == "Clip")
            _player.StartCoroutine(DoubleSword());
        else
            _player.StartCoroutine(CommonSword());
    }

    IEnumerator CommonSword()
    {
        yield return new WaitForSeconds(_player.currentWeaponData.weaponAttackCoolTime / 2);

        AttackPlayer();

        yield return new WaitForSeconds(_player.currentWeaponData.weaponAttackCoolTime / 2);

        _player.isAttack = true;
        _player.animator.SetBool("Attack", false);

        _player.ChangeState(StateEnum.Idle);
    }

    IEnumerator DoubleSword()
    {
        AttackPlayer();

        yield return new WaitForSeconds(_player.currentWeaponData.weaponAttackCoolTime / 2);

        AttackPlayer();

        yield return new WaitForSeconds(_player.currentWeaponData.weaponAttackCoolTime / 2);
        _player.isAttack = true;
        _player.animator.SetBool("Attack", false);
        _player.ChangeState(StateEnum.Idle);
    }

    private void AttackPlayer()
    {
        _player.ShowAttackEffect();
        Collider[] hit = Physics.OverlapBox(_player.RayTransform.position, _player.size, _player.transform.rotation, _player.whatIsEnemy);

        foreach (Collider hittor in hit)
        {
            _player.playerCam.transform.DOShakePosition(0.4f, 0.2f, 10, 90);

            hittor.transform.TryGetComponent(out IDamageable attackIner);

            attackIner.ApplyDamage(_player.currentWeaponData.weaponDamage);
        }
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
}