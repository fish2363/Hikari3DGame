using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControllor : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField]
    private Transform[] points;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();

    }


    public void SetPoint(Transform[] point)
    {
        line.positionCount = point.Length;

        this.points = point;
    }


    private void Update()
    {
        if(SettingManager.Instance.isLine)
        {
            line.enabled = true;
            for (int i = 0; i < points.Length; i++)
            {
                line.SetPosition(i, points[i].position);
            }
        }
        else
        {
            line.enabled = false;
        }
    }
}
