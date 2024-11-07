using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetList = new List<Transform>();

    [Header("Setting")]
    [SerializeField] private GameObject _owner;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _threshold = 0.1f;
    [SerializeField] private int _startIndex;
    [SerializeField] private Vector3 _gizmoSize;

    private Rigidbody _rigid;
    private Transform _currentTarget;
    private float _distance;
    private int _index = 0;

    private void Awake()
    {
        _index = _startIndex;
        _currentTarget = _targetList[_index];

        _rigid = _owner.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckRange();
    }

    private void FixedUpdate()
    {
        MoveWay();
    }

    private void CheckRange()
    {
        Vector3 targetDir = _currentTarget.position - _owner.transform.position;
        _distance = targetDir.magnitude;

        if (_distance <= _threshold)
        {
            Quaternion rotation = Quaternion.LookRotation(targetDir, Vector3.up);
            //나중에 DOTween생기면 DORotate로 rotation만큼 회전하기;

            _index++;

            if( _index >= _targetList.Count)
                _index = 0;

            _currentTarget = _targetList[ _index];
            _rigid.velocity = Vector3.zero;
        }
    }

    private void MoveWay()
    {
        Vector3 moveDir = (_currentTarget.position - _owner.transform.position).normalized;
        moveDir.y = 0;

        _rigid.velocity = moveDir * _speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        foreach (Transform t in _targetList)
        {
            Gizmos.DrawCube(t.position, _gizmoSize);
        }
    }
}
