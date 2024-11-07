using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rbCompo;
    private Vector3 moveDir;
    public Action OnMove;

    private void Awake()
    {
        moveDir = transform.position;
        _rbCompo = GetComponent<Rigidbody>();
    }

    public void CanMove(bool isMove, Transform playerPos, float moveSpeed)
    {
        if (isMove == false)
            _rbCompo.velocity = Vector3.zero;
        else
          moveDir =  Vector3.MoveTowards(transform.position,playerPos.position,moveSpeed);
    }

    
}
