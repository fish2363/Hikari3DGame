using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SkillState : State
{
    private Player _player;
    public SkillState(Player owner) : base(owner)
    {
        _player = owner;
    }

    public override void Enter()
    {
        if (_player.currentWeaponData.name == "Spon")
        {
            _player.StartCoroutine(Skill());
        }
        else if (_player.currentWeaponData.name == "Pencil")
        {
            _player.StartCoroutine(Skill2());
        }

        base.Enter();

    }

    IEnumerator Skill()
    {
        _player.ShowAttackEffect();
        _player.animator.SetBool("Attack", true);
        _player._isSkill = false;

        _player._isSkillCoolTime = false;


        yield return new WaitForSeconds(0.7f);
        AttackPlayer();

        _player._isSkill = true;
        _player.animator.SetBool("Attack", false);

        yield return new WaitForSeconds(18.7f);
        _player._isSkillCoolTime = true;
    }

    IEnumerator Skill2()
    {
        _player.ShowAttackEffect();
        _player.animator.SetBool("Skill", true);
        _player._isSkill = false;

        _player._isSkillCoolTime = false;


        yield return new WaitForSeconds(0.7f);
        CrashEnemy();

        _player._isSkill = true;
        _player.animator.SetBool("Skill", false);

        yield return new WaitForSeconds(18.7f);
        _player._isSkillCoolTime = true;
    }

    public void CrashEnemy()
    {
        
        Collider[] hit = Physics.OverlapBox(_player.RayTransform.position, _player.SkillSize, _player.transform.rotation, _player.whatIsEnemy);

        foreach (Collider hittor in hit)
        {
            _player.playerCam.transform.DOShakePosition(0.4f, 0.2f, 10, 90);

            hittor.TryGetComponent(out IDamageable damamge);

            damamge.ApplyDamage(_player.currentWeaponData.weaponDamage += 30);
        }
    }

    private void AttackPlayer()
    {
        Collider[] hit = Physics.OverlapBox(_player.RayTransform.position, _player.SkillSize, _player.transform.rotation, _player.whatIsEnemy);

        foreach (Collider hittor in hit)
        {
            _player.playerCam.transform.DOShakePosition(0.4f, 0.2f, 10, 90);

            hittor.GetComponent<Enemy>().stateMachine.ChangeState(EnemyStatEnum.Stun);
        }
    }


    public override void StateUpdate()
    {
        base.StateUpdate();
        if(_player._isSkill)
        {
            _player.ChangeState(StateEnum.Idle);
        }
    }
    public override void Exit()
    {
        base.Exit();
 
        _player.animator.SetFloat("Velocity", 0);
    }
}
