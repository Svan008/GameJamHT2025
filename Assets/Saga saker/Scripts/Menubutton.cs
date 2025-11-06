using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menubutton : MonoBehaviour
{
    public GameObject ThingIWantToShow; // panel
    public void onClick() //när man klickar knappen
    {
        ThingIWantToShow.SetActive(true); //då tar man fram panelen 
    }
}
//Saga