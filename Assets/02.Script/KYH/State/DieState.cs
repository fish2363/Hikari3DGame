using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    private Player _player;
    public DieState(Player owner) : base(owner)
    {
        _player = owner;
    }

    public override void Enter()
    {
        _player.StartCoroutine(ChangeDie());
        base.Enter();
    }

    IEnumerator ChangeDie()
    {
        _player.animator.SetBool("Die", true);

        yield return new WaitForSeconds(1.4f);

        _player.gameObject.SetActive(false);
    }
}
