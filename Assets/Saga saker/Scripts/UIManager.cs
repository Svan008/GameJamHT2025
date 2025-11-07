using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public UnitHealth maxHealth;
    public UnitHealth Health;
    public UnitHealth _playerHealth;
    private playerDamage healthManager;
    public Slider healthBar;
    void Start()
    {
        healthManager = FindObjectOfType<playerDamage>();
    }
    void Update()
    {
        healthBar.maxValue = healthManager.maxHealth;
        healthBar.value = healthManager.currentHealth;
    }
}
