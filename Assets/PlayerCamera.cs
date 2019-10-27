using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform LookAt;

    private Vector3 DesiredPosition;
    private float Offset = 0.5f;
    private float Distance = 13.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DesiredPosition = (LookAt.position + -transform.forward * Distance) + (transform.up * Offset);
        transform.position = Vector3.Lerp(transform.position, DesiredPosition, 0.05f);

        transform.LookAt(transform.position + Vector3.forward * Offset);
    }
}
