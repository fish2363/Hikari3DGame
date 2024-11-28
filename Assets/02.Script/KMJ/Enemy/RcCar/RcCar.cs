using System.Collections;
using UnityEngine;

public class RcCar : Enemy
{
    public bool _isSkill;

    public bool _isAttack;

    public bool _isSkillExit;

    public bool _isAttackExit;

    public bool _isLook;

    private Transform _player;

    private Vector3 _moveDir;

    protected override void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _isSkill = true;
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new RcCarIdle(this, stateMachine, "Idle"));
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
        if (_isLook)
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

        Transform playertransform = GameObject.FindWithTag("Player").transform;
        Vector3 moveDir = playertransform.position - transform.position;

        yield return new WaitForSeconds(1f);


        transform.position += moveDir * EnemyStat.AttackPoawer * Time.deltaTime;

        yield return new WaitForSeconds(0.3f);
        _isLook = true;
        _isSkillExit = true;


        yield return new WaitForSecondsRealtime(3f);
        _isSkill = true;
    }

    IEnumerator AttackTime()
    {
        _isAttackExit = false;

        Transform playertransform = GameObject.FindWithTag("Player").transform;

        Vector3 moveDir = playertransform.position - transform.position;


        yield return new WaitForSeconds(0.3f);
        transform.position += moveDir * EnemyStat.AttackPoawer * Time.deltaTime;

        yield return new WaitForSeconds(2f);

        _isAttackExit = true;
    }
}
