using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    public int maxHealth = 100; //max hälsa är 100
    public int currentHealth; // Nuvarande hälsa

    public HealthBar healthBar;
    

    private void Start()
    {
        {
            currentHealth = maxHealth; //max hälsa är nuvarande hälsa
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))//om vi trycker på "Y"
        {
            TakeDamage(10); // Tar player 10 damage
            Debug.Log("Halko");
        }
    }


    void TakeDamage(int damage) //damage
    {
        currentHealth -= damage; // slidern visar nuvarande hälsa minus mängd damage

         healthBar.SetHealth (currentHealth);
    }
}
//Saga
