using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase : MonoBehaviour
{
	public void BossPhases()
    {
        int PhaseCount = Random.Range(1, 4);

        switch (PhaseCount)
        {
            case 1:
                ScissorsPhase1();
                break;
        }
    }

    private void ScissorsPhase1()
    {
        
    }
}
