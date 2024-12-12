using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTraking : MonoBehaviour
{
    [SerializeField] private LineControllor line;
    [SerializeField] private Transform[] point;

    private void Start()
    {
        line.SetPoint(point);
    }
}
