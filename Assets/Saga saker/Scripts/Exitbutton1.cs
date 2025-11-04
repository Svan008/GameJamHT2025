using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitbutton1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}