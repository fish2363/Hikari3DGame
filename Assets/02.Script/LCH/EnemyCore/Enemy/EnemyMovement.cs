using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rbCompo;
    private Vector3 moveDir;

    public Transform playerPos { get;  set; }

    [field : SerializeField] public bool isMove { get; set; }

    private void Awake()
    {
        isMove = false;
        moveDir = transform.position;
        _rbCompo = GetComponent<Rigidbody>();
    }

    public void StopImmediately()
    {
        _rbCompo.velocity = Vector3.zero;
    }


}
