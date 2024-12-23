using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class ScissorsPhase4State : EntityState
{

    private Scissors _scissors;
    private float _originDamge;

    public ScissorsPhase4State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _scissors = entity as Scissors;

    }
    private Transform FindWallOppositeToFacingDirection()
    {
        _scissors.hits = Physics.RaycastAll(
            _scissors.transform.position,
            _scissors.transform.forward,
            Mathf.Infinity,
            _scissors.WhatIsWall
        );
        if (_scissors.hits.Length == 0)
        {
            Debug.LogWarning("Raycast 충돌 없음");
            return null;
        }

        RaycastHit farthestHit = _scissors.hits.OrderByDescending(hit => hit.distance).FirstOrDefault();
        if (farthestHit.collider != null && farthestHit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log(farthestHit.transform.name);
            return farthestHit.collider.transform; 
        }

        Debug.LogWarning("충돌한 객체가 벽이 아님");
        return null;
    }


    public override void Enter()
    {
        base.Enter();
        _originDamge = _scissors.DamgeCaster.Damage;
        _scissors.DamgeCaster.Damage = 45f;

        Transform firstWall = FindWallOppositeToFacingDirection();
        if (firstWall != null)
        {
            Vector3 directionAwayFromWall = firstWall.transform.position;
            Vector3 firstTargetPosition = _scissors.transform.position + directionAwayFromWall * 3f;

            EnemyDash(firstTargetPosition, () =>
            {
                Transform secondWall = FindWallOppositeToFacingDirection();
                if (secondWall != null)
                {
                    Vector3 secondDirectionAwayFromWall = secondWall.transform.position;
                    Vector3 secondTargetPosition = _scissors.transform.position + secondDirectionAwayFromWall * 3f;

                    EnemyDash(secondTargetPosition, () =>
                    {
                        _scissors.StartCoroutine(ChangeToChase());
                    });
                }
                else
                {
                    Debug.LogWarning("두 번째 대쉬 중 벽을 찾을 수 없습니다.");
                    _scissors.StartCoroutine(ChangeToChase());
                }
            });
        }
        else
        {
            Debug.LogWarning("첫 번째 대쉬 중 벽을 찾을 수 없습니다.");
            _scissors.StartCoroutine(ChangeToChase());
        }
    }

    private void EnemyDash(Vector3 target, TweenCallback onComplete)
    {
        Vector3 dashPosition = new Vector3(target.x, _scissors.transform.position.y, target.z);
        float dashDuration = 1.0f;

        _scissors.transform.DOMove(dashPosition, dashDuration)
            .SetEase(Ease.InOutQuad)
            .OnComplete(onComplete);
    }


    private IEnumerator ChangeToChase()
    {
        if (!_scissors.IsDead)
        {
            _scissors.transform.DOJump(_scissors.originPos, 15F, 1, 0.5F);
            yield return new WaitForSeconds(1f);
            _scissors.ChangeState(BossState.Chase);
        }
    }



    public override void UpdateState()
    {
        base.UpdateState();
        _scissors.DamgeCaster.CastDamage();
    }

 //   private Transform FindFarstWall()
	//{
	//	Transform farstWall = null;
	//	float farstDistance = -Mathf.Infinity;

	//	GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
	//	foreach (GameObject wall in walls)
	//	{
	//		float distanceToWall = Vector3.Distance(_scissors.transform.position, wall.transform.position);
	//		if (distanceToWall > farstDistance)
	//		{
	//			farstDistance = distanceToWall;
	//			farstWall = wall.transform;
	//		}
	//	}

	//	return farstWall;
	//}

 //   private Transform FindSideWall()
 //   {
 //       Transform leftWall = null;
 //       Transform rightWall = null;
 //       GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
 //       foreach (GameObject wall in walls)
 //       {
 //           Vector3 directionToWall = (wall.transform.position - _scissors.transform.position).normalized;
 //           float dot = Vector3.Dot(_scissors.transform.right, directionToWall); 

 //           if (dot < 0) leftWall = wall.transform; 
 //           else rightWall = wall.transform;       
 //       }

 //       return Random.value > 0.5f ? leftWall : rightWall;
 //   }

    public override void Exit()
    {
        base.Exit();
        _scissors.DamgeCaster.Damage = _originDamge;
    }
}
//217206