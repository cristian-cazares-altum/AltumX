/*
========================================================
                        Script By:
                    Cristian Cázares
=========================================================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeV2 : MonoBehaviour
{
    //Se declaran los tres colores que se van a usar
    public Color enterColor;
    Color exitColor;
    public Color clickColor;

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
