using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderViewCamera : MonoBehaviour
{
    public Vector3 pivotOffset = new Vector3(.0f, 1.0f, .0f);
    public Vector3 directOffset = new Vector3(.4f, .5f, -2.0f);

    public float smooth = 10f;
    public float horizontalAimingSpd = 6.0f;
    public float verticalAimingSpd = 6.0f;

    public float verticalAngleMax = 30.0f;
    public float verticalAngleMin = -60.0f;
    public float recoilAngleBounce = 5.0f;

    private float horizontalAngle = .0f;
    public float GetHorizontal => horizontalAngle;
    private float verticalAngle = .0f;


    public Transform playerTransform;
    private Transform cameraTransform;
    private Camera myCamera;

    private Vector3 realCameraPosition;
    private float realCameraPositionMag;

    private Vector3 smoothPivotOffset;
    private Vector3 smoothCameraOffset;

    private Vector3 targetPivotOffset;
    private Vector3 targetDirectOffset;

    private float defailtFOV;
    private float targetFOV;

    private float targetMaxVerticleAngle;
    private float recoilAngle = 0f;

    private void Awake()
    {
        cameraTransform = transform;
        myCamera = cameraTransform.GetComponent<Camera>();
        cameraTransform.position
            = playerTransform.position
            + Quaternion.identity * pivotOffset
            + Quaternion.identity * directOffset;
        cameraTransform.rotation = Quaternion.identity;

        realCameraPosition = cameraTransform.position - playerTransform.position;
        realCameraPositionMag = realCameraPosition.magnitude - .5f;
        smoothPivotOffset = pivotOffset;
        smoothCameraOffset = directOffset;
        defailtFOV = myCamera.fieldOfView;
        horizontalAngle = playerTransform.eulerAngles.y;

        ResetTargetOffsets();
        ResetFOV();
        ResetMaxVerticalAngle();
    }

    public void ResetTargetOffsets()
    {
        targetPivotOffset = pivotOffset;
        targetDirectOffset = directOffset;
    }

    public void ResetFOV()
    {
        targetFOV = defailtFOV;
    }

    public void ResetMaxVerticalAngle()
    {
        targetMaxVerticleAngle = verticalAngleMax;
    }

    public void BounceVertical(float degree)
    {
        recoilAngle = degree;
    }

    public void SetTargetOffset(Vector3 newPivotOffset, Vector3 newDirectOffset)
    {
        targetPivotOffset = newPivotOffset;
        targetDirectOffset = newDirectOffset;
    }

    public void SetFOV(float customFOV)
    {
        targetFOV = customFOV;
    }
}
