using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PencilSharpenerPhase3State : EnemyState<BossState>
{

    private PencilSharpener _pencilSharpener;

    public PencilSharpenerPhase3State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        _pencilSharpener.RigidCompo.AddForce(_pencilSharpener.player.transform.position * 10f, ForceMode.Impulse);
     
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_pencilSharpener.WallChecker)
        {
            _pencilSharpener.RigidCompo.velocity = Vector3.zero;
            _pencilSharpener.StartCoroutine(ChangeChaseState());
        }
    }

    private IEnumerator ChangeChaseState()
    {
        _pencilSharpener.WallChecker = false;
        yield return new WaitForSeconds(1f);
        _pencilSharpener.BossStateMachine.ChangeState(BossState.Chase);
    }
}
