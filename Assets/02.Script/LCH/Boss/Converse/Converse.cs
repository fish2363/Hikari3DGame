using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converse : BossBass
{

    private void OnEnable()
    {
       _stateMachine.Initialize(BossState.Chase);
    }

}
