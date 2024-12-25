using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheldState : State
{
    private Player _player;

    public SheldState(Player owner) : base(owner)
    {
        _player = owner;
    }

    public override void Enter()
    {
        base.Enter();
        _player.animator.SetBool("Sheld", true);
        _player.RigidCompo.velocity = UnityEngine.Vector3.zero;
        _player.StartCoroutine(SheldDamage());
    }
    public IEnumerator SheldDamage()
    {
        _player.isShield = false;
        _player.isBlock = false;

        yield return new WaitForSeconds(3);

        _player.isBlock = true;

        yield return new WaitForSeconds(17f);
        _player.isShield = true;
    }

    public override void StateUpdate()
    {
        if (_player.isBlock)
            _player.ChangeState(StateEnum.Idle);
    }

    public override void Exit()
    {
        _player.animator.SetFloat("Velocity", 0);
        _player.animator.SetBool("Sheld", false);
    }

}
