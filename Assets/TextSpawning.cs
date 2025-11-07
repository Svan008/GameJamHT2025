using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawning : MonoBehaviour
{
    [SerializeField] float elapsedTime;
    bool shouldTimer = false;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (shouldTimer)
        {

            elapsedTime += Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shouldTimer = true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (elapsedTime >= 4 && collision.CompareTag("Player"))
        {
            print("<3");
            anim.SetBool("StartPlaying", true);
        }
    }
}
