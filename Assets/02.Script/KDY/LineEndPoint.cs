using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEndPoint : MonoBehaviour
{
    [SerializeField] private Transform[] point;
    [SerializeField] private LineCollider line;


    private void Start()
    {
        line.SetPoint(point);
    }
}
