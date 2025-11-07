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
        float dist = (cam.transform.position.x * parallaxEffect); //

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z); //

       
    }
}
// Sagas
