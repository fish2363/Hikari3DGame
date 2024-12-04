using System.Collections;
using UnityEngine;

public class OttuGi : Enemy
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
        base.Awake();

        _player = GameObject.FindWithTag("Player").transform;

        stateMachine.AddState(EnemyStatEnum.Idle, new OttugiIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new OttuGiWalk(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new OttiGiAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Skill, new OttiGiSkill(this, stateMachine, "Skill"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
    }

    private void Update()
    {
        if (player == null) return;
        stateMachine.CurrentState.UpdateState();


        if (range <= 6)
        {
            MoveCompo.isMove = true;
        }

    }

    public void Attack()
    {
        StartCoroutine(WaitSkill());
    }

    public void Skill()
    {
        if (_childPrefab != null)
        {

            Instantiate(_childPrefab, transform.position, Quaternion.identity);
            Instantiate(_childPrefab, transform.position, Quaternion.identity);

            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    IEnumerator WaitSkill()
    {
        transform.rotation = transform.rotation;

        _isSkillExit = false;
        _isSkilling = true;

        RigidCompo.AddForce(Vector3.up * 7, ForceMode.Impulse);
        RigidCompo.AddForce(transform.forward * 1.3f, ForceMode.Impulse);

        yield return new WaitForSeconds(1.4f);
        _isSkilling = false;

        yield return new WaitForSeconds(1.6f);
        _isSkillExit = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && _isSkilling)
        {
            collision.transform.TryGetComponent(out Player player);
            player.MinusHp(EnemyStat.AttackPoawer);

            RigidCompo.AddForce(Vector3.up * 7, ForceMode.Impulse);
            RigidCompo.AddForce(Vector3.back * 1.3f, ForceMode.Impulse);

        }
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
