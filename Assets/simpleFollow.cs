using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleFollow : MonoBehaviour
{
    public Transform thisTransform, target;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = thisTransform.localRotation;
    }
    private void FixedUpdate()
    {
        thisTransform.position = target.position;
        thisTransform.localRotation = initialRotation;
    }
}
