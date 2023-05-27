using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    private void Awake()
    {
        health = maxHealth;
    }

    public void loseHealth(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
    }

    public void gainHealth(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }
}
