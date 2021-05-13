using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Interpolates a cameras position to another game objects position,
 * typically a player.
 */
public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public void SetCameraTarget(Transform playerTransform)
    {
        target = playerTransform;
    }

    //Offset is added to target position before camera's position
    //is set to the targets with interpolation
    private void LateUpdate()
    {
        try
        {
            Vector3 newPosition = target.position + cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);
        }
        catch (System.Exception) { }
    }
}
