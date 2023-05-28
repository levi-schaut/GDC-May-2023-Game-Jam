using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public HealthBar healthBar;

    private void Awake()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void loseHealth(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;

        healthBar.SetHealth(health);
    }

    public void gainHealth(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;

        healthBar.SetHealth(health);
    }
}
