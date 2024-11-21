using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttuGi : Enemy
{
    public bool _isSkill;

    public bool _isAttack;

    public bool _isSkillExit;

    public bool _isAttackExit;

    protected override void Awake()
    {
        _isSkillExit = true;
        _isSkill = true;
        base.Awake();

        stateMachine.AddState(EnemyStatEnum.Idle, new OttuGiIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new OttuGiWalk(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new OttiGiAttack(this, stateMachine, "Attack"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
    }

    public void Attack()
    {
        StartCoroutine(WaitSkill());
    }

    public void Skill()
    {

    }


    IEnumerator WaitSkill()
    {
        _isSkillExit = false;

        RigidCompo.AddForce(Vector3.up * _enemyStat.AttackPoawer, ForceMode.Impulse);

        yield return new WaitForSeconds(3f);
        _isSkillExit = true;
    }

}
