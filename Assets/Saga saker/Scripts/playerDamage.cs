using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    public int maxHealth = 100; //max h�lsa �r 100
    public int currentHealth; // Nuvarande h�lsa
    public UnitHealth _playerHealth = new UnitHealth(100, 100);
    public healthBar healthBar;
    private bool isTouching;
    private playerDamage healthManager;


    private SpriteRenderer spriteRenderer;
   

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        {
            currentHealth = maxHealth; //max h�lsa �r nuvarande h�lsa
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))//om vi trycker på "Y"
        {
            PlayerTakeDamage(10); // Tar player 10 damage
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }

        if (Input.GetKeyDown(KeyCode.U))
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
