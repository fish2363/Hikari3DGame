using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSharpenerPhase1State : EnemyState<BossState>
{

    private PencilSharpener _pencilSharpener;

    public PencilSharpenerPhase1State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        _pencilSharpener.RigidCompo.AddForce(Vector3.up * 8, ForceMode.Impulse);
        _pencilSharpener.StartCoroutine(AttackWaitCoroutine());
    }

    private IEnumerator AttackWaitCoroutine()
    {
        _pencilSharpener.transform.LookAt(_pencilSharpener.player.transform.position);
        yield return new WaitForSeconds(2f);
        _pencilSharpener.InstanceObj(_pencilSharpener.shotPos, _pencilSharpener.pencilBelt, Quaternion.identity);
        _pencilSharpener.IsPhaseEnd = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_pencilSharpener.RigidCompo.velocity.y < 0)
        {
            _pencilSharpener.RigidCompo.useGravity = false;
        }


        if (_pencilSharpener.IsPhaseEnd)
        {
            _pencilSharpener.RigidCompo.useGravity = true;
            _pencilSharpener.transform.rotation = Quaternion.Euler(0, 0, 0);
            _pencilSharpener.StartCoroutine(ChangeChaseState());
        }
    }

    private IEnumerator ChangeChaseState()
    {
        _pencilSharpener.IsPhaseEnd = false;
        yield return new WaitForSeconds(1f);
        _pencilSharpener.BossStateMachine.ChangeState(BossState.Chase);
    }

    public override void Exit()
    {
        base.Exit();
    }
}