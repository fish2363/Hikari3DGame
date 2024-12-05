using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWindUpDoll : WindUpDoll
{
    public GameObject explostionEffect;

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Walk, new BWindUpDollMove(this, stateMachine, "Move"));
        stateMachine.AddState(EnemyStatEnum.Attack, new BWindUpDollAttack(this, stateMachine, "Attack"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
<<<<<<< HEAD
        transform.position = startPos;
=======
>>>>>>> parent of 828a0d3 (Merge pull request #58 from fish2363/KimMin)
    }

    protected override void Update()
    {
        base.Update();
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
