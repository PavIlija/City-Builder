using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void LateUpdate()
    {
        Camera.main.orthographicSize=Mathf.Clamp(Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") 
            * (10f * Camera.main.orthographicSize*.1f),2.5f,50f);    
    }
}
