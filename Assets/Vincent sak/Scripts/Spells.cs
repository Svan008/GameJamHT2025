using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

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

    private void Update()
    {
        if (isAutomatic)
        {
            shooting = Input.GetKey(KeyCode.O);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.O); 
        }

        if(canShoot && shooting)
        {
            Shoot();
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
        bulletCopy.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shootingForce, ForceMode2D.Impulse);

        Invoke("ResetShot", shootingCooldown);
    }

    private void ResetShot()
    {
        canShoot = true;
    }
}
