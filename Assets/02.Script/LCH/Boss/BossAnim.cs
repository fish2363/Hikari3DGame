using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
	[SerializeField] private BossBass _boss;

	public void AnimationEnd()
    {
        _boss.AnimEndTrigger();
    }
}
