using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    public Transform cam;

    private GameObject cameraLoc;

    void Start()
    {
        cameraLoc = GameObject.Find("FPCcamera");
        cam = cameraLoc.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
