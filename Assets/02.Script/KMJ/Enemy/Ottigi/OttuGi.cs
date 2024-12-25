using System.Collections;
using UnityEngine;

public class OttuGi : Enemy, IDamageable
{
    public bool _isSkill;

    public bool _isAttack;

    public bool _isSkillExit;

    public bool _isAttackExit;

    private Transform _player;

    public bool _isSkilling;


    [SerializeField] private GameObject _childPrefab;


    protected override void Awake()
    {
        _isSkillExit = true;
        _isSkill = true;
        _isSkilling = false;
        base.Awake();

        _player = GameObject.FindWithTag("Player").transform;

        stateMachine.AddState(EnemyStatEnum.Idle, new OttugiIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new OttuGiWalk(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new OttiGiAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Skill, new OttiGiSkill(this, stateMachine, "Skill"));
        stateMachine.AddState(EnemyStatEnum.Stun, new RcStun(this, stateMachine, "Idle"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
    }

    private void Update()
    {
        if (player == null) return;

        range = Vector3.Distance(transform.position, _player.transform.position);


        if (range <= 10)
        {
            MoveCompo.isMove = true;
        }


        stateMachine.CurrentState.UpdateState();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.LateUpdateState();
    }

    public void Attack()
    {
        StartCoroutine(WaitSkill());
    }

    public void Skill()
    {
        if (_childPrefab != null)
        {
            StartCoroutine(Die());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    IEnumerator WaitSkill()
    {
        transform.rotation = transform.rotation;

        _isSkill = false;
        _isSkillExit = false;
        _isSkilling = true;

        RigidCompo.AddForce(Vector3.up * 7, ForceMode.Impulse);
        RigidCompo.AddForce(transform.forward * 1.3f, ForceMode.Impulse);

        yield return new WaitForSeconds(0.5f);
        _isSkill = false;

        yield return new WaitForSeconds(1f);
        _isSkillExit = true;
        _isSkill = true;

        yield return new WaitForSeconds(5f);
        _isSkilling = false;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(_childPrefab, transform.position, Quaternion.identity);
        Instantiate(_childPrefab, transform.position, Quaternion.identity);

        gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isSkill)
        {
            int damage = Random.Range(EnemyStat.MinAttackDamage, EnemyStat.MaxAttackDamage);
            collision.transform.TryGetComponent(out Player player);
            player.ApplyDamage(damage);

            RigidCompo.AddForce(Vector3.up * 7, ForceMode.Impulse);
            RigidCompo.AddForce(Vector3.back * 2.5f, ForceMode.Impulse);

        }
    }

    protected override void AnimEndTrigger()
    {

    }

    protected override void EnemyDie()
    {

    }

    public void Attack(Player agent, LayerMask hittable, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }


    public void ApplyDamage(float damage)
    {
        Hp -= damage;
        var hit = Instantiate(getDamageEffect);
        hit.SetPositionAndPlay(transform.position, transform);
    }
}
