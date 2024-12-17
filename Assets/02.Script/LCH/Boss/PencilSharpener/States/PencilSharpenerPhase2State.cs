using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PencilSharpenerPhase2State : EnemyState<BossState>
{

    private PencilSharpener _pencilSharpener;
    private Vector3 playerPosition;
    private int Count = 0;
    public PencilSharpenerPhase2State(EnemyAgent enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
        _pencilSharpener = enemy as PencilSharpener;
    }
    public override void Enter()
    {
        base.Enter();
        Count = 10;
        playerPosition = _pencilSharpener.player.transform.position;
        _pencilSharpener.StartCoroutine(DropBoomCoroutine());
    }

    private IEnumerator DropBoomCoroutine()
    {
        while (Count > 0 && !_pencilSharpener.IsPhaseEnd)
        {
            yield return new WaitForSeconds(0.5f); 
            DropBoom(); 
        }

        if (Count <= 0 && !_pencilSharpener.IsPhaseEnd)
        {
            _pencilSharpener.IsPhaseEnd = true;
            _pencilSharpener.StartCoroutine(ChangeChaseState());
        }
    }

    private void DropBoom()
    {
        if (Count > 0 && !_pencilSharpener.IsPhaseEnd)
        {
            playerPosition = _pencilSharpener.player.transform.position;
            playerPosition = new Vector3(playerPosition.x, playerPosition.y + 10, playerPosition.z); 

            GameObject fallingObject = GameObject.Instantiate(_pencilSharpener._fallingObjectPrefab, playerPosition, Quaternion.identity);

            Rigidbody rb = fallingObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
            }

            Count--; 
        }
    }

    private IEnumerator ChangeChaseState()
    {
        yield return new WaitForSeconds(1F);
        _pencilSharpener.BossStateMachine.ChangeState(BossState.Chase);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
