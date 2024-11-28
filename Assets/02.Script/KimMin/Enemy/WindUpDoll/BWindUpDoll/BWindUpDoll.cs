using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWindUpDoll : WindUpDoll
{
    public GameObject explostionEffect;

    public float explostionTime = 3.0f;


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

    public void InstantiateObject(GameObject targetObj, Vector3 pos)
    {
        Instantiate(targetObj, pos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(startPos, moveRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, nextPos);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, EnemyStat.AttackRadius);  
    }
}
