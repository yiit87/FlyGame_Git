using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController PlayerController;
    private float DefaultSpeed = 10f;
    private float RotationSpeedX = 80f;
    private float RotationSpeedY = 80f;

    private bool UsingAccelerometer = false;
    private bool PC = true;
    private Dictionary<int, Vector2> ActiveTouches = new Dictionary<int, Vector2>();


    private void Start()
    {
        PlayerController = GetComponent<CharacterController>();
    }
    public Vector3 GetPlayerInput()
    {
        ////This part written for mobile phone contros however its not complete
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
        //This part written for mobile phone contros however its not complete
        //*******************************************************************
        //Vector3 moveVector = transform.forward * DefaultSpeed;

        //Vector3 inputsPlayer = GetPlayerInput();

        //Vector3 yaw = inputsPlayer.x * Vector3.right  *RotationSpeedX * Time.deltaTime;
        //Vector3 pitch = inputsPlayer.y * Vector3.up  * 100 * RotationSpeedY * Time.deltaTime;

        //Vector3 rol = inputsPlayer.x * Vector3.forward * 200* Time.deltaTime;
        //Vector3 RollUp = inputsPlayer.z * Vector3.right * 50*  RotationSpeedX * Time.deltaTime;

        //Vector3 direction = yaw + pitch;

        //Vector3 PlaneRoll = rol + RollUp;

        //float maxX = Quaternion.LookRotation(moveVector).eulerAngles.x;

        //if (maxX < 90 && maxX > 70 || maxX > 270 && maxX < 290)
        //{

        //}
        //else
        //{
        //    moveVector += direction;
        //    Debug.Log(moveVector);


        //    transform.rotation = Quaternion.LookRotation(moveVector);
        //}
        //PlayerController.Move(moveVector * Time.deltaTime);


        if (Input.GetKey(KeyCode.Q))
        {
            DefaultSpeed++;
        }
        if (Input.GetKey(KeyCode.E))
        {
            DefaultSpeed--;
        }
        transform.position += transform.forward * Time.deltaTime * DefaultSpeed;
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
    }
}
