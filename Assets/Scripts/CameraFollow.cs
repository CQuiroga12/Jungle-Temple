using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    private void Awake()
    {
        //SetCameraTarget(target);
    }

    public void SetCameraTarget(Transform playerTransform)
    {
        target = playerTransform;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = target.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);
    }
}
