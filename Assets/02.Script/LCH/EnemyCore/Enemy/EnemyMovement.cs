using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody _rbCompo;
    private Vector3 moveDir;

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody>();
    }

    public void CanMove(bool isMove , float moveSpeed)
    {
        if (isMove == false)
            _rbCompo.velocity = Vector3.zero;
        else
            _rbCompo.velocity = moveDir * moveSpeed;
    }

    
}
