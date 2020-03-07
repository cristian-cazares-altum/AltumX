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
    //Instanciadores Obligatorios
    [Header("Fuentes")]
    [Header("Código por Cristian Cázares")]
    [Tooltip("Instrucción: Arrastrar \"Main Camera\"")]
    public Transform CameraTransform;
    CharacterController Controller;


    //Activadores Opcionales
    [Header("Camara Alternativa (Tecla \"ESC\")")]
    [Tooltip("Explicación: Con GvrEditorEmulator no podemos usar el movimiento de mouse y las teclas de movimiento (wasd) al mismo tiempo." +
        "\nAl activar la cámara alternativa podemos hacerlo sin problemas. \nSE ACTIVA PRESIONANDO LA TECLA \"ESC\"")]
    public bool altCam;
    [Tooltip("Variable para ajustar la sensibilidad del mouse.")]
    public float MouseSense = 150f;

    //Herramienta Extra para ver posicion del Joystick
    [Header("Herramientas Extras")]
    public bool PrintJoystick;


    [Header("Variables movimiento")]
    //Variables Move
    public float speed = 5f;
    public float gravity = -9.81f;
    Vector3 Vel;


    //Variables AltCamMovment
    float xRot = 0f;
    GameObject gvr;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        altCam = false;
        gvr = GameObject.Find("GvrEditorEmulator");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Move();

        //Al presionar "esc", activar Cámara Alternativa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!altCam)
            {
                altCam = true;
            }
            else
            {
                altCam = false;
            }
        }
        //Aplicar Camara Alternativa
        if (altCam)
        {
            AltCamMove();
            gvr.active = false;

        }
        else
        {
            gvr.active = true;
        }
    }

    void Move()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = CameraTransform.right * x + CameraTransform.forward * z;

        Controller.Move(move * speed * Time.deltaTime);

        Vel.y += gravity * Time.deltaTime;

        Controller.Move(Vel * Time.deltaTime);


        //ValoresJoystick
        if (PrintJoystick)
        {
            Debug.Log(x + ", " + z);
        }
    }


    void AltCamMove()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxis("Mouse X") * MouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSense * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        CameraTransform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        GetComponent<Transform>().Rotate(Vector3.up * mouseX);
    }

}
