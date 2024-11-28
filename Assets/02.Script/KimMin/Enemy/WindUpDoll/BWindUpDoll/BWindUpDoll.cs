using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWindUpDoll : WindUpDoll
{
    public float moveRadius = 15f;
    public float explostionTime = 3.0f;

    public GameObject explostionEffect;

    public Vector3 startPos;
    private Vector3 _nextPos;
    private Vector3 _prev;


    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Walk, new BWindUpDollMove(this, stateMachine, "Move"));
        stateMachine.AddState(EnemyStatEnum.Attack, new BWindUpDollAttack(this, stateMachine, "Attack"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
        transform.position = startPos;
    }

    protected override void Update()
    {
        base.Update();
        Debug.Log(stateMachine.CurrentState);
        stateMachine.CurrentState.UpdateState();
    }

    public Vector3 GetNextPos()
    {
        Vector3 radius = new Vector3(startPos.x + moveRadius, startPos.y, startPos.x + moveRadius);

        Vector3 result = new Vector3(
            Random.Range(radius.x, -radius.x), startPos.y,
            Random.Range(radius.z, -radius.z));

        _nextPos = result;

        if (_prev != null && (_prev - result).magnitude < 5)
        {
            return GetNextPos();
        }

        return result;
    }

    public void InstantiateObject(GameObject targetObj, Vector3 pos)
    {
        Instantiate(targetObj, pos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(startPos, moveRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, _nextPos);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _enemyStat.AttackRadius);
    }
}
