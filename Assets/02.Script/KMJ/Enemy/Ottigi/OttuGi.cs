using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttuGi : Enemy
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

        stateMachine.AddState(EnemyStatEnum.Idle, new OttugiIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new OttuGiWalk(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new OttiGiAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Skill, new OttiGiSkill(this, stateMachine, "Skill"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
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
        Instantiate(_childPrefab);
        Instantiate(_childPrefab);

        gameObject.SetActive(false);
    }


    IEnumerator WaitSkill()
    {
        _isSkillExit = false;

        

        RigidCompo.AddForce(Vector3.up * EnemyStat.AttackPoawer, ForceMode.Impulse);

        bool ishit = Physics.Raycast(transform.position,Vector3.down, 2,whatIsPlayer);

        if (ishit == true)
        {
            Debug.Log("Ã¼·Â±ðÀ½");
        }

        yield return new WaitForSeconds(3f);
        _isSkillExit = true;
    }
}
