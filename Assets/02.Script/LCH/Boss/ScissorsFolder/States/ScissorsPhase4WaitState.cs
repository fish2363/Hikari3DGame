using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScissorsPhase4WaitState : EntityState
{
	private Scissors _scissors;
	private Transform _nearestWall;

    public ScissorsPhase4WaitState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
		_scissors = entity as Scissors;

	}

	public override void Enter()
	{
		base.Enter();
		_scissors.originPos = _scissors.transform.position;

		//_nearestWall = FindNearestWall();
		//Vector3 directionAwayFromWall = (_scissors.transform.position - _nearestWall.position).normalized;
		//Vector3 targetPosition = _nearestWall.position - directionAwayFromWall * 3f;
		//Sequence seq = DOTween.Sequence();
		//seq.Append(_scissors.transform.DOJump(targetPosition, 15f, 0, 1f)).Append(_scissors.transform.DOMoveY(targetPosition.y, 0.5f)).
		//	AppendCallback(() => _scissors.StartCoroutine(ChangeToPhase4State()));

		_nearestWall = FindNearestWall();
		Vector3 wallCenter = _nearestWall.position;
		Vector3 directionAwayFromWall = (_scissors.transform.position - wallCenter).normalized;
		Vector3 jumpTargetPosition = wallCenter - directionAwayFromWall * 3f;

		Sequence seq = DOTween.Sequence();

		seq.Append(_scissors.transform.DOJump(jumpTargetPosition, 15f, 1, 1f)) 
		   .AppendCallback(() => {
	   RaycastHit hit;
			   if (Physics.Raycast(jumpTargetPosition, Vector3.down, out hit, Mathf.Infinity, _scissors._groundChecker))
			   {
				   Vector3 groundPosition = hit.point;
		   _scissors.transform.DOMoveY(groundPosition.y, 0.5f)
					   .OnComplete(() => _scissors.StartCoroutine(ChangeToPhase4State()));
			   }
			   else
			   {
				   Debug.LogWarning("Ground 레이어에 닿지 않았습니다.");
				   _scissors.StartCoroutine(ChangeToPhase4State()); 
	   }
		   });

	}

    public override void UpdateState()
    {
        base.UpdateState();
		_scissors.DamgeCaster.CastDamage();
		Vector3 direction = _scissors.player.transform.position - _scissors.transform.position;

		direction.y = 0;


		if (direction.sqrMagnitude > 0.001f)
		{
			direction.Normalize();

			Quaternion lookRotation = Quaternion.LookRotation(direction);

			_scissors.transform.rotation = lookRotation;
		}
	}

    private IEnumerator ChangeToPhase4State()
	{
		yield return new WaitForSeconds(0.5f);
		_scissors.ChangeState(BossState.Phase4);
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
