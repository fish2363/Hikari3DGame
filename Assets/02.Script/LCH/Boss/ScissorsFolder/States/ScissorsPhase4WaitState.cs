using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScissorsPhase4WaitState : EnemyState<BossState>
{

    private Scissors _scissors;
    private Transform _nearestWall;

    public ScissorsPhase4WaitState(EnemyAgent enemy, StateMachine<BossState> state, string animHashName)
        : base(enemy, state, animHashName)
    {
        _scissors = enemy as Scissors;
    }

    public override void Enter()
    {
        base.Enter();
        _scissors.originPos = _scissors.transform;

        _nearestWall = FindNearestWall();

        if (_nearestWall != null)
        {
            Vector3 directionAwayFromWall = (_scissors.transform.position - _nearestWall.position).normalized;
            Vector3 targetPosition = _nearestWall.position - directionAwayFromWall * 5f;

            _scissors.transform.DOJump(
                targetPosition,
                15f,
                1,
                0.5f
            ).OnComplete(() =>
            {
                _scissors.RigidCompo.velocity = Vector3.zero;
                _scissors.transform.position = targetPosition;
                _scissors.StartCoroutine(ChangeToPhase4State());
            });
        }
    }

    private IEnumerator ChangeToPhase4State()
    {
        yield return new WaitForSeconds(1f);
        _scissors.BossStateMachine.ChangeState(BossState.Phase4);
    }

    private Transform FindNearestWall()
    {
        Transform nearestWall = null;
        float nearestDistance = Mathf.Infinity;

        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            float distanceToWall = Vector3.Distance(_scissors.transform.position, wall.transform.position);
            if (distanceToWall < nearestDistance)
            {
                nearestDistance = distanceToWall;
                nearestWall = wall.transform;
            }
        }

        return nearestWall;
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
