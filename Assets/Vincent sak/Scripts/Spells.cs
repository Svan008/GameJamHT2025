using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

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

    [SerializeField] bool facingRight = true;
    [SerializeField] bool facingLeft;

    private float amountOfSpread;

    private bool shooting;
    private bool canShoot;

    private void Start()
    {
        canShoot = true;
    }

    private void Update()
    {
        if (isAutomatic)
        {
            shooting = Input.GetKey(KeyCode.L);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.L); 
        }

        if(canShoot && shooting)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        }

    }

    private void Shoot()
    {
        canShoot = false;

        //Spread
        amountOfSpread = Random.Range(-spread, spread);

        quaternion rotAfterSpread = Quaternion.Euler(firePoint.position.x,
            firePoint.position.y,
            firePoint.position.z + amountOfSpread);


        //Spawna bullet
        GameObject bulletCopy = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        firePoint.rotation = rotAfterSpread;
        
        Invoke("ResetShot", shootingCooldown);
    }

    private void ResetShot()
    {
        canShoot = true;
    }
}
