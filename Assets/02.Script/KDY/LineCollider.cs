using UnityEngine;

public class LineCollider : MonoBehaviour
{
    LineRenderer _line;
    [SerializeField] Transform[] _point;
    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }


    public void SetPoint(Transform[] points)
    {
        _line.positionCount = points.Length;
        _point = points;
    }


    private void Update()
    {
        for (int i = 0; i < _point.Length; i++)
            _line.SetPosition(i, _point[i].position);
    }
}
