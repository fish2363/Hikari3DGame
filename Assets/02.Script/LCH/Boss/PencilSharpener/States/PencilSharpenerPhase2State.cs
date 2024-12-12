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

        if(Count <= 0)
        {
            _pencilSharpener.StartCoroutine(ChangeChaseState());
        }
    }

    private IEnumerator DropBoomCoroutine()
    {
        if (Count > 0)
        {
            yield return new WaitForSeconds(0.5f);
            DropBoom();
            Count -= 1;
        }
    }

    private IEnumerator ChangeChaseState()
    {
        yield return new WaitForSeconds(1F);
    
         _pencilSharpener.BossStateMachine.ChangeState(BossState.Chase);
          _pencilSharpener.IsPhaseEnd = false;
    }

    private void DropBoom()
    {
         playerPosition = _pencilSharpener.player.transform.position;

         Vector3 spawnPosition = playerPosition + GetRandomPositionAroundPlayer();

         GameObject fallingObject = GameObject.Instantiate(_pencilSharpener._fallingObjectPrefab, spawnPosition, Quaternion.identity);
        
         Rigidbody rb = fallingObject.GetComponent<Rigidbody>();
         if (rb != null)
         {
              rb.useGravity = true;
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
