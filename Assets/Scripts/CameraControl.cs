using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform target; 
    public Vector3 offset = new Vector3(0f, 2f, -5f); 

    public float smoothSpeed = 0.125f;
    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: Target not set!");
            return;
        }

        
        Vector3 desiredPosition = target.position + offset;

       
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

       
        transform.position = smoothedPosition;

       
        transform.LookAt(target);
    }
}


