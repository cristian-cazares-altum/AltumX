/*
========================================================
                        Script By:
                    Cristian Cázares
Change the color of a simple object using the
GVRReticlePointer from the Google Cardboard SDK (GVR).
=========================================================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    //Se declaran los tres colores que se van a usar
    [Header("Colores a cambiar:")]
    [Header("Código por Cristian Cázares")]
    public Color enterColor;
    public Color clickColor;
    Color exitColor;

    void Start()
    {
        exitColor = GetComponent<Renderer>().material.color;
    }


    //Se asignan dichos colores
    public void Enter()
    {
        GetComponent<Renderer>().material.color = enterColor;
    }
    public void Exit()
    {
        GetComponent<Renderer>().material.color = exitColor;
    }
    public void Click()
    {
        GetComponent<Renderer>().material.color = clickColor;
    }
}
