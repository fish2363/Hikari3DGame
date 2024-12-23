using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase2WaitState : EntityState
{

    private Scissors _scissors;

    public ScissorsPhase2WaitState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;

    }

    public override void Enter()
    {
        base.Enter();
        _scissors.StartCoroutine(ChangePhase2State());
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Vector3 direction = _scissors.player.transform.position - _scissors.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _scissors.transform.rotation = lookRotation;
        }
    }

    private IEnumerator ChangePhase2State()
    {
        Debug.Log("너 이상해");
        yield return new WaitForSeconds(1f);
        _scissors.ChangeState(BossState.Phase2);
    }
}