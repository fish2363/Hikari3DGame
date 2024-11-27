using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsClone : MonoBehaviour
{
    private Rigidbody _rbCompo;
    [SerializeField] private float _dashPower = 8f;

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _rbCompo.AddForce(Vector3.right * _dashPower);
        }
    }
}
