/*
========================================================
                        Script By:
                    Cristian Cázares
=========================================================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //Se declaran los tres colores que se van a usar
    public Color enterColor;
    public Color exitColor;
    public Color clickColor;


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
