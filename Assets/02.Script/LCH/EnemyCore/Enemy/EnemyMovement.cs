using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rbCompo;
    private Vector3 moveDir;

    public Transform playerPos { get;  set; }

    public bool isMove { get; set; }

    private void Awake()
    {
        isMove = true;
        moveDir = transform.position;
        _rbCompo = GetComponent<Rigidbody>();
    }

    public void CanMove(float moveSpeed)
    {
         transform.position = Vector3.MoveTowards(transform.position,playerPos.position,moveSpeed * Time.deltaTime);

        if (isMove == false)
            moveDir = Vector3.zero;
    }

    public void StopImmediately()
    {
        _rbCompo.velocity = Vector3.zero;
    }


}
