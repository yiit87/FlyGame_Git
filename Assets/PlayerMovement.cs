using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool UsingAccelerometer = false;

    private Dictionary<int, Vector2> ActiveTouches = new Dictionary<int, Vector2>();

    public Vector3 GetPlayerInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            float x = 0 - Time.deltaTime;
          //  Debug.Log(x);
            return new Vector3(x,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            float x = 0 + Time.deltaTime;
            //  Debug.Log(x);
            return new Vector3(x, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            float y = 0 - Time.deltaTime;
            //  Debug.Log(x);
            return new Vector3(0, y, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            float y = 0 + Time.deltaTime;
            //  Debug.Log(x);
            return new Vector3(0, y, 0);
        }

        if (UsingAccelerometer)
        {
            Vector3 acceleration = Input.acceleration;
            acceleration.y = acceleration.z;
            return acceleration;
        }
        else
        {
            Vector3 touches = Vector3.zero;

            foreach (Touch touch in Input.touches)
            {
                //we start pressing the screen
                if (touch.phase == TouchPhase.Began)
                {
                    ActiveTouches.Add(touch.fingerId, touch.position);
                }
                //we stop pressing the screen
                else if (touch.phase == TouchPhase.Ended)
                {
                    if (ActiveTouches.ContainsKey(touch.fingerId))
                    {
                        ActiveTouches.Remove(touch.fingerId);
                    }
                }
                //figer is moving or waiting
                else
                {
                    float magnit = 0f;
                    touches = (touch.position - ActiveTouches[touch.fingerId]);
                    magnit = touches.magnitude / 300;
                    touches = touches.normalized * magnit;
                }
            }
            return touches;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 userInput = GetPlayerInput();
       
        Debug.Log(userInput);
        transform.position += Vector3.forward * 3 * Time.deltaTime;
        transform.position += userInput;
    }
}
