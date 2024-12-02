using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase2State : EnemyState<BossState>
{
    private Scissors _scissors;
    private bool _isAttackWait;
    public ScissorsPhase2State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
    }

    public override void Enter()
    {
        base.Enter();
        _scissors.StartCoroutine(AttackWaitCoroutine());
    }

    private IEnumerator AttackWaitCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _isAttackWait = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_isAttackWait && !_scissors.IsPhaseEnd)
        {
            _scissors.RigidCompo.AddForce(Vector3.up * 40, ForceMode.Impulse);
            if(_scissors.RigidCompo.velocity.magnitude < 0)
            {
                _scissors.RigidCompo.useGravity = false;
                _scissors.transform.position = _scissors.player.transform.position;
            }
        }
    }


}
