using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Ami.BroAudio;

public class PencilSharpenerPhase2State : EntityState
{

    private PencilSharpener _pencilSharpener;
    private Vector3 playerPosition;
    private int Count = 0;

    public PencilSharpenerPhase2State(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _pencilSharpener = entity as PencilSharpener;

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

        BroAudio.Play(_pencilSharpener.Phase2Sfx);

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
        if (!_pencilSharpener.IsDead)
        {

            yield return new WaitForSeconds(1F);
            _pencilSharpener.ChangeState(BossState.Chase);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
