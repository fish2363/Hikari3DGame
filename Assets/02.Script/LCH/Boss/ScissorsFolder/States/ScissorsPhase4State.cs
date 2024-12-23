using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScissorsPhase4State : EntityState
{

    private Scissors _scissors;
    private float _originDamge;

    public ScissorsPhase4State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;

    }

    public override void Enter()
    {
        base.Enter();
        _originDamge = _scissors.DamgeCaster.Damage;
        _scissors.DamgeCaster.Damage = 45f;
        Transform farWall = FindFarstWall();
		Vector3 directionAwayFromWall = (_scissors.transform.position - farWall.position).normalized;
		Vector3 targetPosition = farWall.position - directionAwayFromWall * 3f;


        EnemyDash(targetPosition, () =>
        {
            Transform sideWall = FindSideWall();
            Vector3 dirAwayFromWall = (_scissors.transform.position - sideWall.position).normalized;
            Vector3 targetSidePosition = sideWall.position - dirAwayFromWall * 3f;
            EnemyDash(targetSidePosition, () =>
            {
                Transform LastWall = FindFarstWall();
                Vector3 LastdirAwayFromWall = (_scissors.transform.position - LastWall.position).normalized;
                Vector3 LasttargetPosition = LastWall.position - LastdirAwayFromWall * 3f;
                EnemyDash(LasttargetPosition, ()=> _scissors.StartCoroutine(ChangeToChase()));
            });
        });
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _scissors.DamgeCaster.CastDamage();
    }

    private IEnumerator ChangeToChase()
    {
        _scissors.transform.DOJump(_scissors.originPos, 15F, 1, 0.5F);
        yield return new WaitForSeconds(1f);
        _scissors.ChangeState(BossState.Chase);
    }

    private Transform FindFarstWall()
	{
		Transform farstWall = null;
		float farstDistance = -Mathf.Infinity;

		GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
		foreach (GameObject wall in walls)
		{
			float distanceToWall = Vector3.Distance(_scissors.transform.position, wall.transform.position);
			if (distanceToWall > farstDistance)
			{
				farstDistance = distanceToWall;
				farstWall = wall.transform;
			}
		}

		return farstWall;
	}

    private Transform FindSideWall()
    {
        Transform leftWall = null;
        Transform rightWall = null;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            Vector3 directionToWall = (wall.transform.position - _scissors.transform.position).normalized;
            float dot = Vector3.Dot(_scissors.transform.right, directionToWall); 

            if (dot < 0) leftWall = wall.transform; 
            else rightWall = wall.transform;       
        }

        return Random.value > 0.5f ? leftWall : rightWall;
    }

    private void EnemyDash(Vector3 target, TweenCallback onComplete)
    {
        if (target == null) return;

        Vector3 dashPosition = new Vector3(target.x, _scissors.transform.position.y, target.z);

        float dashDuration = 1.0f;

        _scissors.transform.DOMove(dashPosition, dashDuration)
            .SetEase(Ease.InOutQuad)
            .OnComplete(onComplete);
    }

    public override void Exit()
    {
        base.Exit();
        _scissors.DamgeCaster.Damage = _originDamge;
    }
}
//217206