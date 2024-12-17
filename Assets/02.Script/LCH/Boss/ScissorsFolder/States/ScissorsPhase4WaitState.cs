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
		_scissors.originPos = _scissors.transform.position;

		_nearestWall = FindNearestWall();
		Vector3 directionAwayFromWall = (_scissors.transform.position - _nearestWall.position).normalized;
		Vector3 targetPosition = _nearestWall.position - directionAwayFromWall * 3f;
		Sequence seq = DOTween.Sequence();
		seq.Append(_scissors.transform.DOJump(targetPosition, 15f, 0, 1f)).
			AppendCallback(() => _scissors.StartCoroutine(ChangeToPhase4State()));
	}

	private IEnumerator ChangeToPhase4State()
	{
		Debug.Log("³¡³ª¹ö·Ç");
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

}
