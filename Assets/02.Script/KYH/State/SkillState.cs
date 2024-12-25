using Ami.BroAudio;
using DG.Tweening;
using System.Collections;
using UnityEngine;

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
        BroAudio.Play(_player._sponSwingSfx);
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


    public IEnumerator Skill2()
    {
        player.animator.SetBool("Sheld", true);
        _player.RigidCompo.velocity = UnityEngine.Vector3.zero;
        _player._isSkill = false;
        _player.isFullSheld = true;

        _player._isSkillCoolTime = false;

        yield return new WaitForSeconds(3);

        _player._isSkill = true;
        _player.animator.SetBool("Sheld", false);
        _player.isFullSheld = false;

        yield return new WaitForSeconds(17f);
        _player._isSkillCoolTime = true;
    }


private void AttackPlayer()
{
    Collider[] hit = Physics.OverlapBox(_player.RayTransform.position, _player.SkillSize, _player.transform.rotation, _player.whatIsEnemy);

    foreach (Collider hittor in hit)
    {
        _player.playerCam.transform.DOShakePosition(0.4f, 0.2f, 10, 90);

            if (hittor.TryGetComponent(out Enemy enemy))
            {
                BroAudio.Play(_player._sponAttackSfx);
                enemy.stateMachine.ChangeState(EnemyStatEnum.Stun);
            }
            else
                return;
    }
}


public override void StateUpdate()
{
    base.StateUpdate();
    if (_player._isSkill)
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
