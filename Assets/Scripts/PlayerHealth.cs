using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    int health;

    public HealthBar healthBar;
    public LoseScreen loseScreen;

    private void Awake()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void loseHealth(int amount)
    {
        health -= amount;
        if (health < 0) { 
            health = 0;
        }

        healthBar.SetHealth(health);

        if (health == 0) {
            loseScreen.LoseGame();
        }
    }

    public void gainHealth(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;

        healthBar.SetHealth(health);
    }
}
