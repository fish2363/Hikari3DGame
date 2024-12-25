using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ami.BroAudio;

public class ScissorsAttackCompo : MonoBehaviour ,IEntityComponent
{

    private DamageCast _damgeCast;
    private Scissors _scissors;

    private void Awake()
    {
        _damgeCast = GetComponentInChildren<DamageCast>();
    }

    public void Phase1Attack()
    {
        BroAudio.Play(_scissors.ScissorsFastSfx);
        _damgeCast.CastDamage();
    }

    public void ChaseAttack()
    {
        //BroAudio.Play(_scissors.ScissorsSfx);
        _damgeCast.CastDamage();
    }

    public void Phase3Attack()
    {
        BroAudio.Play(_scissors.QuickScissorsSfx);
        _damgeCast.CastDamage();
    }

    public void Initialize(Entity entity)
    {
        _scissors = entity as Scissors;
    }
}
