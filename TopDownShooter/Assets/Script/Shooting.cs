using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Shooting : MonoBehaviour
{

    public Weapon currentWeapon; // object of weapon class
    public Transform firePoint;
    //public GameObject bulletPrefab;
    public float bulletForce = 20f;
    //public float fireRate =100f;
    public float nextfire = 0f;

       
    void Update()
    {
        Vector2 shootVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal_2"), CrossPlatformInputManager.GetAxis("Vertical_2"));

        if (shootVector.sqrMagnitude > 0.8 && Time.time > nextfire)
        {
            Shoot();
        }
    } 

    void Shoot()
    {
        nextfire = Time.time + 1/currentWeapon.fireRate;
        GameObject bullet = Instantiate(currentWeapon.bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
