using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SheldState : State
{
    private Player _player;
    private bool _isSheldOut;
   
    public SheldState(Player owner) : base(owner)
    {
        _player = owner;
    }

    public override void Enter()
    {
        base.Enter();
        _player.animator.SetBool("Sheld", true);
        _player.RigidCompo.velocity = UnityEngine.Vector3.zero;
       // StartCoroutine(SheldDamage());
    }

    public override void StateUpdate()
    {
        if (_isSheldOut)
            _player.ChangeState(StateEnum.Idle);
    }

    public override void Exit()
    {
        _player.animator.SetBool("Sheld", false);
    }

    IEnumerator SheldDamage()
    {
        _isSheldOut = false;
        _player.isSheld = false;

        _player.armorSheld = 25;
        yield return new WaitForSeconds(3);

        _player.armorSheld = 0;
        _player.isSheld = true;
        _isSheldOut = true;
    }
}
