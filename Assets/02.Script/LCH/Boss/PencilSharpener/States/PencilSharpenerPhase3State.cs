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
        Transform nearestWall = FindNearestWall();
        if (nearestWall != null)
        {
            Vector3 directionToWall = (nearestWall.position - _pencilSharpener.transform.position).normalized;

            _pencilSharpener.RigidCompo.AddForce(directionToWall * 7f, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("벽을 찾을 수 없습니다!");
        }
    }

    private Transform FindNearestWall()
    {
        Transform nearestWall = null;
        float nearestDistance = Mathf.Infinity;

        Collider[] walls = Physics.OverlapSphere(_pencilSharpener.transform.position, 20f, LayerMask.GetMask("Wall"));
        foreach (Collider wall in walls)
        {
            float distanceToPlayer = Vector3.Distance(wall.transform.position, _pencilSharpener.player.transform.position);

            if (distanceToPlayer < nearestDistance)
            {
                nearestDistance = distanceToPlayer;
                nearestWall = wall.transform;
            }
        }

        return nearestWall;
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
