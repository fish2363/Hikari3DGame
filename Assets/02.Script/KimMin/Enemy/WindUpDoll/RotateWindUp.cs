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
        transform.RotateAround(transform.position, Vector3.right, speed * Time.deltaTime);
    }
}
