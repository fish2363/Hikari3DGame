using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PencilSharpenerPhase1State : EntityState
{

    private PencilSharpener _pencilSharpener;
    private Vector3 _oringinPos;

    public PencilSharpenerPhase1State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _pencilSharpener = entity as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        _oringinPos = new Vector3(_pencilSharpener.transform.position.x
            ,_pencilSharpener.transform.position.y,_pencilSharpener.transform.position.z);
        _pencilSharpener.transform.DOMoveY(_pencilSharpener.JumpPos.position.y,1.2F);
        _pencilSharpener.StartCoroutine(AttackWaitCoroutine());
    }

    private IEnumerator AttackWaitCoroutine()
    {
        _pencilSharpener.transform.LookAt(_pencilSharpener.player.transform);
        yield return new WaitForSeconds(2f);
        GameObject.Instantiate(_pencilSharpener.pencilBelt, _pencilSharpener.shotPos);
        _pencilSharpener.RigidCompo.useGravity = true;
        _pencilSharpener.transform.rotation = Quaternion.Euler(0, 0, 0);
        _pencilSharpener.StartCoroutine(ChangeChaseState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_pencilSharpener.RigidCompo.velocity.y < 0)
        {
            _pencilSharpener.RigidCompo.useGravity = false;
        }
    }

    private IEnumerator ChangeChaseState()
    {
        if (!_pencilSharpener.IsDead)
        {
            _pencilSharpener.transform.DOMove(_oringinPos, 0.5f);
            yield return new WaitForSeconds(1f);
            _pencilSharpener.ChangeState(BossState.Chase);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
