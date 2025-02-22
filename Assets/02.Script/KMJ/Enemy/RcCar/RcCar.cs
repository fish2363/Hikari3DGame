using System.Collections;
using UnityEngine;

public class RcCar : Enemy, IDamageable
{
    public bool _isAttack;
    public bool _isSkill;
    public bool _isMove;
    public bool _isAttackTrue;
    public bool _isSkillTrue;

    public bool _isLook;

    private Transform _player;

    private Vector3 _moveDir;

    public ShowEffect hitEffect;
    [SerializeField]
    private float moveSpeed = 10f;

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
        stateMachine.AddState(EnemyStatEnum.Stun, new RcStun(this, stateMachine, "Stun"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
        _isSkillTrue = false;
        _isAttackTrue = false;
    }

    private void Update()
    {

        range = Vector3.Distance(transform.position, _player.transform.position);


        if (player == null) return;
        stateMachine.CurrentState.UpdateState();

        if (range <= 10)
        {
            MoveCompo.isMove = true;
        }

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

        RigidCompo.velocity += moveDir * 10;

        yield return new WaitForSeconds(0.1f);
        RigidCompo.velocity = Vector3.zero;

        _isSkillTrue = false;
        _isLook = true;
        _isMove = true;

        yield return new WaitForSeconds(1.5f);

        _isAttack = true;

        yield return new WaitForSecondsRealtime(8f);
        _isSkill = true;


    }

    IEnumerator AttackTime()
    {
        _isAttack = false;
        _isMove = false;

        Transform playertransform = GameObject.FindWithTag("Player").transform;

        Vector3 moveDir = playertransform.position - transform.position;

        _isAttackTrue = true;

        RigidCompo.velocity += moveDir * moveSpeed;

        yield return new WaitForSeconds(0.1f);

        RigidCompo.velocity = Vector3.zero;
        _isAttackTrue = false;
        _isMove = true;

        yield return new WaitForSeconds(3f);
        _isAttack = true;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //�⺻����
            int damage = Random.Range(EnemyStat.MinAttackDamage, EnemyStat.MaxAttackDamage);
            collision.transform.TryGetComponent(out IDamageable player);

            if (_isAttackTrue)
            {
                player.ApplyDamage(damage);
                stateMachine.ChangeState(EnemyStatEnum.Stun);

            }
            else if (_isSkillTrue)
            {
                stateMachine.ChangeState(EnemyStatEnum.Stun);
                player.ApplyDamage(damage += 2);
            }

            RigidCompo.velocity = Vector3.zero;


        }
    }

    protected override void AnimEndTrigger()
    {
        throw new System.NotImplementedException();
    }
    protected override void EnemyDie()
    {

    }

    public void Attack(Player agent, LayerMask hittable, Vector3 direction)
    {

    }

    public void ApplyDamage(float damage)
    {
        Hp -= damage;
        var hit = Instantiate(hitEffect);
        hit.SetPositionAndPlay(transform.position, transform);
    }
}
