using System.Collections;
using UnityEngine;

public class RcCar : Enemy
{
    public bool _isAttack;
    public bool _isSkill;
    public bool _isMove;
    public bool _isAttackTrue;
    public bool _isSkillTrue;

    public bool _isLook;

    private Transform _player;

    private Vector3 _moveDir;

   

    protected override void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _isSkill = true;
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new RcCarIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new RcCarMove(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new RcCarAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Skill, new RcCarSkill(this, stateMachine, "Skill"));
        stateMachine.AddState(EnemyStatEnum.Dead, new RcCarDie(this, stateMachine, "Die"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
        _isSkillTrue = false;
        _isAttackTrue = false;
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
      
    }

    public void DashSkill()
    {
        StartCoroutine(Skill());
    }

    public void Attack()
    {
        StartCoroutine(AttackTime());
    }


    IEnumerator Skill()
    {
        

        _isLook = false;
        _isAttack = false;
        _isSkill = false;
        _isMove = false;

        Transform playertransform = GameObject.FindWithTag("Player").transform;
        Vector3 moveDir = playertransform.position - transform.position;

        yield return new WaitForSeconds(1f);
        _isSkillTrue = true;
        transform.position += moveDir * EnemyStat.AttackPoawer * Time.deltaTime;

        yield return new WaitForSeconds(0.3f);
        _isSkillTrue = false;
        _isLook = true;
        _isMove = true;

        yield return new WaitForSeconds(1.5f);

        _isAttack = true;

        yield return new WaitForSecondsRealtime(1f);
        _isSkill = true;

       
    }

    IEnumerator AttackTime()
    {
        _isAttack = false;
        _isMove = false;

        Transform playertransform = GameObject.FindWithTag("Player").transform;

        Vector3 moveDir = playertransform.position - transform.position;

        _isAttackTrue = true;
        transform.position += moveDir * EnemyStat.AttackPoawer * Time.deltaTime;

        yield return new WaitForSeconds(0.2f);
        _isAttackTrue = false;
        _isMove = true;
        yield return new WaitForSeconds(2f);
        _isAttack = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && _isAttackTrue)
        {
            //기본공격
        }
        else if(collision.gameObject.CompareTag("Player") && _isSkillTrue)
        {
           //스킬공격
        }

        RigidCompo.velocity = Vector3.zero;
    }

    protected override void AnimEndTrigger()
    {
        throw new System.NotImplementedException();
    }

    protected override void EnemyDie()
    {
        throw new System.NotImplementedException();
    }
}
