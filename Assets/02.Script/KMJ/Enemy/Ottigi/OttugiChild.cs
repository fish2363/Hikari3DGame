using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttugiChild : Enemy
{
    public bool _isSkill;

    public bool _isAttack;

    public bool _isSkillExit;

    public bool _isAttackExit;

    private Transform _player;

    [SerializeField] private GameObject _childPrefab;

    protected override void Awake()
    {
        _isSkillExit = true;
        _isSkill = true;
        base.Awake();

        _player = GameObject.Find("Player").transform;

        stateMachine.AddState(EnemyStatEnum.Walk, new OttugiChildWalkk(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new OttugiChildAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Skill, new OttugiChildSkill(this, stateMachine, "Skill"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();

        transform.LookAt(_player);
    }

    public void Attack()
    {
        StartCoroutine(WaitSkill());
    }

    public void Skill()
    {
        gameObject.SetActive(false);
    }


    IEnumerator WaitSkill()
    {
        _isSkillExit = false;

        Vector3.MoveTowards(transform.position, _player.transform.position, 10);

        RigidCompo.AddForce(Vector3.up * _enemyStat.AttackPoawer, ForceMode.Impulse);

        yield return new WaitForSeconds(3f);
        _isSkillExit = true;
    }
}
