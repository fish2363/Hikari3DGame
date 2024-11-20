using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : BossBase
{
    private void Start()
    {
        BossAttack();
    }
    public override void BossAttack()
    {
        StartCoroutine(PhasePulse(1f));
    }

    private IEnumerator PhasePulse(float timer)
    {
        yield return new WaitForSeconds(timer);
        OnphaseEvent?.Invoke();
    }

    public override void BossyDie()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

        }
    }
}
