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

    public ObjectPooler bulletPooler;

    void Start()
    {
        bulletPooler = this.GetComponent<ObjectPooler>();
    }

    void Update()
    {
        Vector2 shootVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal_2"), CrossPlatformInputManager.GetAxis("Vertical_2"));

        if (shootVector.sqrMagnitude > 0.8 && Time.time > nextfire)
        {
            Shoot();
        }
    } 


    //Bullet Generator
    void Shoot()
    {   
        nextfire = Time.time + 1/currentWeapon.fireRate;
        //Getting a Bullet object from ObjectPooler and assiging it to "newBullet"
        GameObject newBullet = (GameObject)bulletPooler.GetPooledObject();
        if (newBullet != null)
        {
            //Assiging the position of the bullet
            newBullet.transform.position = firePoint.position;
            newBullet.transform.rotation = firePoint.rotation;
            Rigidbody2D rb =  newBullet.GetComponent<Rigidbody2D>();

            //Enabling Gameobject and assigning force
            newBullet.SetActive(true);
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
    public int getWeaponDamage()
    {
        return currentWeapon.getDamage();
    }
}
