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
        moveDir = transform.position;
        _rbCompo = GetComponent<Rigidbody>();
    }

    public void CanMove(float moveSpeed)
    {
         moveDir = Vector3.MoveTowards(transform.position,playerPos.position,moveSpeed);
    }

    
}
