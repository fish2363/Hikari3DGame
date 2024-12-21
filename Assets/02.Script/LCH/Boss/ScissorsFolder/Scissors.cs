using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : BossBass
{

    public Vector3 originPos;

    private void Start()
    {
        _stateMachine.Initialize(BossState.Chase);
    }
}
