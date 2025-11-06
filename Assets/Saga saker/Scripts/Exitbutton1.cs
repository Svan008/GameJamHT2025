using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitbutton1 : MonoBehaviour
{
    void Update() // När spelet startar
    {
        if (Input.GetKey("escape")) // om du trycker på esc knappen
        {
            Application.Quit();// så går du ut ur spelet
        }
    }
}