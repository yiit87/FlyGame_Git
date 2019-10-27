using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform LookAt;

    // Update is called once per frame
    void Update()
    {
        //Look At the airplane at all times
        Vector3 CameraMove = transform.position - transform.forward * 10 + Vector3.up * 5f;
        //float bias = 0.96f;
        //transform.position = transform.position * bias + CameraMove * (1.0f - bias);
        transform.LookAt(LookAt.position + transform.forward * 30f);
    }
}
