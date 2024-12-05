using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    private BoxCollider _pickableCollider;

    private void Awake()
    {
        _pickableCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp(collision.GetComponent<Player>());
            Destroy(gameObject);
        }
    }

    public abstract void PickUp(Player agent);
}
