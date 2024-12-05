using System.Collections;
using UnityEngine;

public class Soilder : Enemy, IAttackable
{
    public Vector3 startPos;
    public float moveRadius = 10;

    private Vector3 _prev = Vector3.zero;

    public bool _isAttack { get; set; }
    [field: SerializeField] public bool _isMove { get; set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Walk, new SoilderWalk (this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Chase, new SoilderChase(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyStatEnum.Attack, new SoilderShoot(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Dead, new SoilderDie(this, stateMachine, "Die"));

        _isAttack = true;
        _isMove = false;
    }

    private void Start()
    {
        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
    }

    public Vector3 GetNextPos()
    {
        Vector3 radius = new Vector3(startPos.x + moveRadius, startPos.y , startPos.z + moveRadius);

        Vector3 result = new Vector3(Random.Range(radius.x, -radius.x),startPos.y, Random.Range(radius.z, -radius.z));


        if (_prev != null && (_prev - result).magnitude < 5)
        {
            return GetNextPos();
        }

        return result;
    }

    private void Update()
    {
        if (player == null) return;
        stateMachine.CurrentState.UpdateState();

        if (range <= 5)
        {
            _isMove = true;
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

    public void Attack(Player agent, LayerMask hittable, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void HitEnemy(float damage, float knockbackPower)
    {
        hp -= damage;
    }
}
