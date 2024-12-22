using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;

    [SerializeField]
    private float speed;
    public CinemachineVirtualCamera virtualCamera;

    private Vector3 difValue;
    public float Yaxis;
    public float Xaxis;

    private float rotSensitive = 3f;
    private float rotationMin = -10f;
    private float rotationMax =80f;
    private float smoothTime =0.02f;
    [SerializeField]
    private float distance =7f;
    private Vector3 currentVel;

    //private void Start()
    //{
    //    difValue = transform.position - followTarget.transform.position;
    //    difValue = new Vector3(Mathf.Abs(difValue.x), Mathf.Abs(difValue.y) - 3, Mathf.Abs(difValue.z));
    //}

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }


    private void LateUpdate()
    {
        Yaxis = Yaxis + Input.GetAxis("Mouse X") * rotSensitive;
        Xaxis = Xaxis + Input.GetAxis("Mouse Y") * rotSensitive;

        Xaxis = Mathf.Clamp(Xaxis, rotationMin, rotationMax);

        difValue = Vector3.SmoothDamp(difValue, new Vector3(Xaxis, Yaxis),
            ref currentVel, smoothTime);
        this.transform.eulerAngles = difValue;

        transform.position = followTarget.position - transform.forward * distance;
    }

    private void Update()
    {
        //transform.position = Vector3.Lerp(transform.position,
        //    followTarget.transform.position - difValue, speed
        //    );
    }
}
