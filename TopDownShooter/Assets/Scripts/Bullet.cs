using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                this.gameObject.SetActive(false);
                timer = 1.5f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Shooting shoot = GameObject.Find("Player").GetComponent<Shooting>();
        Enemy01 enemy = collision.GetComponent<Enemy01>();

        if (enemy != null)
        {
            enemy.TakeDamage(shoot.getWeaponDamage());
            this.gameObject.SetActive(false);
        }
    }

}
