using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWindUp : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.rotation *= Quaternion.Euler(0, 0, speed * Time.deltaTime);
    }
}
