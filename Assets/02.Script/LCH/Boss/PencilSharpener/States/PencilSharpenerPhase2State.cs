using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PencilSharpenerPhase2State : EnemyState<BossState>
{

    private PencilSharpener _pencilSharpener;
    private Vector3 playerPosition;
    private Vector3 _yRange;
    private Vector3 _xRange;
    private float _spawnRadius = 5f;
    private int Count = 10;
    public PencilSharpenerPhase2State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }

    public override void Enter()
    {
        base.Enter();
        playerPosition = _pencilSharpener.player.transform.position;
        _pencilSharpener.StartCoroutine(DropBoomCoroutine());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(Count <= 0)
        {
            _pencilSharpener.IsPhaseEnd = true;
        }
    }

    private IEnumerator ChangeChaseStaet()
    {
        yield return new WaitForSeconds(1F);
        _pencilSharpener.BossStateMachine.ChangeState(BossState.Chase);
    }

    private IEnumerator DropBoomCoroutine()
    {
        while(Count >= 0)
        {
            yield return new WaitForSeconds(0.5f);
            DropBoom();
        }
        yield return null;
    }

    private void DropBoom()
    {
        if (!_pencilSharpener.IsPhaseEnd)
        {
            playerPosition = _pencilSharpener.player.transform.position;

            Vector3 spawnPosition = playerPosition + GetRandomPositionAroundPlayer();

            GameObject fallingObject = GameObject.Instantiate(_pencilSharpener._fallingObjectPrefab, spawnPosition, Quaternion.identity);

            Rigidbody rb = fallingObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
            }
            Count -= 1;
        }
        if (_pencilSharpener.IsPhaseEnd)
        {
           _pencilSharpener.StartCoroutine(ChangeChaseStaet());
            return;
        }
       
    }

    private Vector3 GetRandomPositionAroundPlayer()
    {
        float angle = Random.Range(0, 360);
        float x = Mathf.Cos(angle) * _spawnRadius;
        float z = Mathf.Sin(angle) * _spawnRadius;
        return new Vector3(x, 10f, z);
    }

    public override void Exit()
    {
        base.Exit();
        Count = 10;
    }
}
