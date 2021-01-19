using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    public int maximumHealth = 100;
    public int currentHealth = 0;
    public HealthBar healthbar; 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
        healthbar.SetMaxHealth(maximumHealth);
    }

    public void TakeDamage(int damage) {
        this.currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
