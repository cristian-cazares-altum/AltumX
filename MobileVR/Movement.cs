/*
========================================================
                        Script By:
                    Cristian Cázares
FPS Movement.
=========================================================
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController Controller;
    public Transform CameraTransform;

    public float speed = 5f;
    public float gravity = -9.81f;

    Vector3 Vel;
    public bool PrintJoystick;


    // Update is called once per frame
    void Update()
    {
        //GetComponent<Transform>().rotation = CameraTransform.rotation;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = CameraTransform.right * x + CameraTransform.forward * z;

        Controller.Move(move * speed * Time.deltaTime);

        if (PrintJoystick)
        {
            Debug.Log(x + ", " + z);
        }

        Vel.y += gravity * Time.deltaTime;

        Controller.Move(Vel * Time.deltaTime);


    }
}
