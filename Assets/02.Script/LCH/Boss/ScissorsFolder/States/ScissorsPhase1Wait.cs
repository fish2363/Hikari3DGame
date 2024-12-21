using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase1Wait : EntityState
{
    private Scissors _scissors;

    public ScissorsPhase1Wait(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;

    }

    public override void Enter()
    {
        base.Enter();
        _scissors.StartCoroutine(ChangePhase1State());
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

    private IEnumerator ChangePhase1State()
    {
        Debug.Log("�����̻���");
        yield return new WaitForSeconds(1f);
        _scissors.ChangeState(BossState.Phase1);
    }
}
