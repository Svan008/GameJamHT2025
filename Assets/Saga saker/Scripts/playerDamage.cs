using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    public int maxHealth = 100; //max hälsa är 100
    public int currentHealth; // Nuvarande hälsa

    public HealthBar healthBar;
    private float waitToHurt = 2f;
    private bool isTouching;
    private playerDamage healthManager;
    public int damageToGive = 10;
    public int HurtPlayer;

    private SpriteRenderer spriteRenderer;
   

    private void Start()
    {
        //ResetHealth();

        spriteRenderer = GetComponent<SpriteRenderer>();
        //GameController
        {
            currentHealth = maxHealth; //max hälsa är nuvarande hälsa
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Trap trap = collision.GetComponent<Trap>();
        //if (trap && trap.damage>0)
        //
        //    TakeDamage(trap.damage);

        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))//om vi trycker på "Y"
        {
            PlayerTakeDamage(10); // Tar player 10 damage
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }

    private void PlayerTakeDamage(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
    }
    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
    }
}
//Saga
