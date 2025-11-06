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

    //[SerializeField] Transform firePoint;
    //[SerializeField] GameObject bulletPrefab;
    //[SerializeField] GameObject bulletPrefab2;
    //[SerializeField] LayerMask whatIsEnemy;

    [SerializeField] bool facingRight = true;
    [SerializeField] bool facingLeft;

    private float amountOfSpread;

    private bool shooting;
    private bool canShoot;

    private void Start()
    {
        //ändrar canShoot till true vid uppstart Vincent
        canShoot = true;
    }

    private void Update()
    {
        //kollar om attacken är automatisk, om det är skjuter den med att hålla in knappen Vicnent
        if (isAutomatic)
        {
            shooting = Input.GetKey(KeyCode.L);
        }
        //om vapnet inte är automatiskt behöver man klicka för att skjuta Vincent
        else
        {
            shooting = Input.GetKeyDown(KeyCode.L); 
        }

        //kollar om man kan skjuta och skjuter för att ge tillåtelse att skjuta Vicnent
        if(canShoot && shooting)
        {
            Shoot();
        }

        //klickar på L eller O för att använda olika bullet prefabs Vincent
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    Instantiate(bulletPrefab2, firePoint.position, transform.rotation);
        //}
    }

    private void Shoot()
    {
        //när man skjutit ändras canShoot till false
        canShoot = false;

        //Spread
        amountOfSpread = Random.Range(-spread, spread);

        //quaternion rotAfterSpread = Quaternion.Euler(firePoint.position.x,
        //    firePoint.position.y,
        //    firePoint.position.z + amountOfSpread);


        //Spawnar en bullet
        //GameObject bulletCopy = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        //firePoint.rotation = rotAfterSpread;
        
        //startar ResetShot funktionen
        Invoke("ResetShot", shootingCooldown);
    }

    //ändrar canShoot till true
    private void ResetShot()
    {
        canShoot = true;
    }
}
