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
        _player.StartCoroutine(Skill());
        _player.animator.SetBool("Attack", true);
        base.Enter();

    }

    IEnumerator Skill()
    {
        _player._isSkill = false;

        _player._isSkillCoolTime = false;


        yield return new WaitForSeconds(0.93f);
        AttackPlayer();

        _player._isSkill = true;

        yield return new WaitForSeconds(18.7f);
        _player._isSkillCoolTime = true;
    }

    private void AttackPlayer()
    {
        _player.ShowAttackEffect();
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
        _player.animator.SetBool("Attack", false);
        _player.animator.SetFloat("Velocity", 0);
    }
}
