using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap : MonoBehaviour
{
    public float bounceForce = 10f; //man studsar när man colliderar
    public int damage = 10; //om man glr kontakt får man 10 damage

    private void OnTriggerEnter2D(Collider2D collision)//när man collidar
    {
        if (collision.gameObject.CompareTag("Player"))//om sakenhar tag "Player"
        {
                HandlePlayerBounce(collision.gameObject);//dår får player studs
        }
    }
   private void  HandlePlayerBounce (GameObject player)//players rigidbody rör object
   {
          Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
         
        if (rb)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); //då får player velocity på x axeln

            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);// och player åjer upp
        }
   }

}
