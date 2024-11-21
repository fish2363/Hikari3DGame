using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCar : Enemy
{
    public bool _isSkill;

    public bool _isAttack;

    public bool _isSkillExit;

    public bool _isAttackExit;

    private Transform _player;

    protected override void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _isSkill = true;
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new RcCarIdle(this,stateMachine,"Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new RcCarMove(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new RcCarAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Skill, new RcCarSkill(this, stateMachine, "Skill"));
        stateMachine.AddState(EnemyStatEnum.Dead, new RcCarDie(this, stateMachine, "Die"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(_player);
    }

    public void DashSkill()
    {
        Debug.Log("¿¿");
        StartCoroutine(Skill());
    }

    public void Attack()
    {
        StartCoroutine(AttackTime());
    }


    IEnumerator Skill()
    {
        _isSkill = false;
        _isSkillExit = false;


        yield return new WaitForSeconds(2f);
        _isSkillExit = true;

        yield return new WaitForSecondsRealtime(3f);
        _isSkill = true;
    }

    IEnumerator AttackTime()
    {
        _isAttackExit = false;


        yield return new WaitForSeconds(2f);

        _isAttackExit = true;
    }
}
