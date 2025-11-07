using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos; // length finns
    public GameObject cam; //kamera finns
    public float parallaxEffect; // parallax effekt finns

    void Start() // När spelet startar
    {
        startpos = transform.position.x; //kamerans startposition
        length = GetComponent<SpriteRenderer>().bounds.size.x; // längd på hur långt bilderna renderas
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));  // 
        float dist = (cam.transform.position.x * parallaxEffect); //

        if (temp > startpos + length) startpos += length; //
        else if (temp < startpos - length) startpos -= length; // 
    }
}


// Sagas
