using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindUpDoll : Enemy
{
    [HideInInspector] public float _distance;

    public Vector3 startPos;
    public Vector3 nextPos;
    public float moveRadius;

    private Vector3 _prev;

    protected virtual void Update()
    {
        _distance = (player.transform.position - transform.position).magnitude;
    }

    public Vector3 GetNextPos()
    {
        Vector3 radius = new Vector3(startPos.x + moveRadius, startPos.y, startPos.x + moveRadius);

        Vector3 result = new Vector3(
            Random.Range(radius.x, -radius.x), startPos.y,
            Random.Range(radius.z, -radius.z));


        if (_prev != null && (_prev - result).magnitude < 5)
        {
            return GetNextPos();
        }

        return result;
    }
}
