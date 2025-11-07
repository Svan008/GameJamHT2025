using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textAnimation : MonoBehaviour
{

    private Animator anim;
    [SerializeField]float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 5.3)
        {
            print("TextAnimChange");
           // anim.SetBool("animarionPlayed", true);
            
        }
        
    }
}
