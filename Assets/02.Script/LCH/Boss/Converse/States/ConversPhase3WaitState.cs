using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversPhase3WaitState : EntityState
{
    private Converse _converse;

    public ConversPhase3WaitState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _converse = entity as Converse;
    }

    public override void Enter()
    {
        base.Enter();
        _converse.StartCoroutine(ChangePhase3State());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector3 direction = _converse.player.transform.position - _converse.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _converse.transform.rotation = lookRotation;
        }
    }

    private IEnumerator ChangePhase3State()
    {
        yield return new WaitForSeconds(1f);
        _converse.ChangeState(BossState.Phase3);
    }
}
