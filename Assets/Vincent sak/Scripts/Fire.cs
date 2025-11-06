using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour   
{
    [SerializeField]
    private Rigidbody2D bullet;

    [SerializeField]
    private Transform firePoint;

    private float bulletSpeed = 500f;

    string currentMagicName;

    // Start is called before the first frame update
    void Start()
    {
        currentMagicName = gameObject.name.Substring(0, name.IndexOf("_"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MagicFire(currentMagicName);
        }
    }

    private void MagicFire(string magicName)
    {
        if (magicName == "Missile")
        {
            var spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            spawnedBullet.AddForce(firePoint.up * bulletSpeed);
        }
        else if (magicName == "Spreadshot")
        {
            for (int i = 0; i <= 2; i++)
            {
                var spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);


                switch (i)
                {
                    case 0:
                        spawnedBullet.AddForce(firePoint.up * bulletSpeed + new Vector3(0f, -90f, 0f));
                        break;
                    case 1:
                        spawnedBullet.AddForce(firePoint.up * bulletSpeed + new Vector3(0f, 0f, 0f));
                        break;
                    case 2:
                        spawnedBullet.AddForce(firePoint.up * bulletSpeed + new Vector3(0f, 90f, 0f));
                        break;
                }
            }
        }
    }
}
