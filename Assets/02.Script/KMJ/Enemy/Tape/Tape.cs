using System;
using System.Collections;
using UnityEngine;

public class Tape : Enemy, IAttackable
{
    public bool _isAttack;

    public bool _isTrueMove;

    [SerializeField] private GameObject _tapeBulletPrbs;

    protected override void Awake()
    {

        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new TapeIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new TapeWalk(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Dead, new TapeDie(this, stateMachine, "Die"));
        stateMachine.AddState(EnemyStatEnum.Attack, new TapeAttack(this, stateMachine, "Attack"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
        _isAttack = true;
    }

    private void Update()
    {
        if (player == null) return;

        stateMachine.CurrentState.UpdateState();

        if (range <= 8)
        {
            MoveCompo.isMove = true;
        }
    }

    public void Attack()
    {
        StartCoroutine(AttackAndWait());
    }

    private IEnumerator AttackAndWait()
    {
        _isAttack = false;
        _isTrueMove = false;

        Instantiate(_tapeBulletPrbs, transform.position, Quaternion.identity);


        yield return new WaitForSeconds(2.4f);

        _isTrueMove = true;

        yield return new WaitForSeconds(6f);

        _isAttack = true;
    }

    protected override void AnimEndTrigger()
    {
        throw new NotImplementedException();
    }

    protected override void EnemyDie()
    {
        throw new NotImplementedException();
    }

    public void Attack(Player agent, LayerMask hittable, Vector3 direction)
    {
        throw new NotImplementedException();
    }

    public void HitEnemy(float damage, float knockbackPower)
    {
        Hp -= damage;
    }
}
