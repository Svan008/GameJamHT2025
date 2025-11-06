using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    private float bounce = 10f; //jumpPad ger 10 bounce

    private void OnCollisionEnter2D(Collision2D collision) //När någon går in i den
    {
       if (collision.gameObject.CompareTag("Player")) //Och någon har tagen "Player"
        {
            collision.gameObject.GetComponent<Rigidbody2D> ().AddForce(Vector2.up * bounce, ForceMode2D.Impulse); //Om "Player" Tag nuddar jumpPadden skjuts han upp

        }
    }
}
//Saga