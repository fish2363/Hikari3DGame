using Ami.BroAudio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWindUpDoll : WindUpDoll
{
    public GameObject explostionEffect1;
    public GameObject explostionEffect2;
    public GameObject explosionSmokeEffect;

    [field: SerializeField] public SoundID ExplosionSound { get; set; }
    [field: SerializeField] public SoundID ExplosionIgnition { get; set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Walk, new BWindUpDollMove(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new BWindUpDollAttack(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStatEnum.Dead, new BWindUpDollDead(this, stateMachine, "Dead"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
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
