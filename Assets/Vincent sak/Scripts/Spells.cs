using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    [SerializeField] int Damage;

    [SerializeField] float shootingCooldown;
    [SerializeField] float spread;
    [SerializeField] float shootingForce;

    [SerializeField] bool isAutomatic;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] LayerMask whatIsEnemy;

    private float amountOfSpread;

    private bool shooting;
    private bool canShoot;

    private void Start()
    {
        canShoot = true;
    }
}
