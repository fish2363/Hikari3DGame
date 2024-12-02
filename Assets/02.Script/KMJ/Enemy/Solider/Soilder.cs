using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soilder : Enemy
{
    public Vector3 startPos;
    public float moveRadius;

    private Vector3 _prev = Vector3.zero;

    public bool _isAttack { get; set; }
    [field : SerializeField] public bool _isMove { get; set; }

    [SerializeField] private GameObject _bulletPrefab;

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new SoilderIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new SoilderWalk(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new SoilderShoot(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Dead, new SoilderDie(this, stateMachine, "Die"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle,this);

        _isAttack = true;
    }

    public Vector3 GetNextPos()
    {
        Vector3 radius = new Vector3(startPos.x + moveRadius, startPos.y, startPos.x + moveRadius);

        Vector3 result = new Vector3(
            Random.Range(radius.x, -radius.x), startPos.y,
            Random.Range(radius.z, -radius.z));


        if (_prev != null && (_prev - result).magnitude < 5)
        {
            return GetNextPos();
        }

        return result;
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        stateMachine.CurrentState.UpdateState();
    }

    public void Attack()
    {
        StartCoroutine(AttackCoolTime());
    }

    IEnumerator AttackCoolTime()
    {
        _isAttack = false;
        _isMove = false;

        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);


        yield return new WaitForSeconds(1.3f);

        _isMove = true;

        yield return new WaitForSeconds(2f);
        _isAttack = true;
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
