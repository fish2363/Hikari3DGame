using DG.Tweening;
using UnityEngine;

public class ClosestObjectFinder : MonoBehaviour
{
    public float searchRadius = 5.0f;
    public LayerMask targetLayer = 0;
    [SerializeField] private Transform targetTransform = null;
    private bool PathSerchRadius = false;
    private bool SerchFlag = true;
    Collider closest = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            closest = FindClosestObject(transform.position, searchRadius, targetLayer);
            if (SerchFlag)
            { SerchFlag = false; }
            if (!SerchFlag) 
            { SerchFlag = true; }
          
           
            if (closest != null)
            {
                PathSerchRadius = true;
                targetTransform.position = closest.transform.GetChild(0).position;
            }


            else
            {
                Debug.Log("연호 코는 기네스 신기록");
            }
        }
        if (PathSerchRadius && !SerchFlag)
        {
            transform.DOLookAt(closest.transform.position, 0.5f);
        }


    }

    Collider FindClosestObject(Vector3 position, float radius, LayerMask layerMask)
    {
        Collider[] colliders = Physics.OverlapSphere(position, radius, layerMask);

        Collider closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            float distance = Vector3.Distance(position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = collider;
            }
        }

        return closest;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
}