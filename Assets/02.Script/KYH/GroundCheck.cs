using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundLayer;

    public bool IsGrounded()
    {
        Vector3 boxSize = new Vector3(transform.lossyScale.x, 0.4f, transform.lossyScale.z);
        return Physics.CheckBox(groundCheck.position, boxSize, Quaternion.identity, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 boxSize = new Vector3(transform.lossyScale.x, 0.4f, transform.lossyScale.z);
        Gizmos.DrawWireCube(groundCheck.position, boxSize);
    }
}
