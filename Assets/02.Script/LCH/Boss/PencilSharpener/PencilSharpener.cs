using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSharpener : BossBass
{

    [field : SerializeField] public Pencil pencilBelt;
    [field: SerializeField] public Transform shotPos;

    [field : SerializeField] public GameObject _fallingObjectPrefab;

    private void Start()
    {
        _stateMachine.Initialize(BossState.Chase);
    }

    public void InstanceObj(Transform transform, Object prefab, Quaternion qut)
    {
        Instantiate(prefab, transform.position, qut);
    }

}
