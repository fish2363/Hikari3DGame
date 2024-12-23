using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCamera : MonoBehaviour
{
    public GameObject cameraTrans;

    
    // Update is called once per frame
    void Update()
    {
        transform.DOMove(cameraTrans.transform.position,0.1f);
    }
}
