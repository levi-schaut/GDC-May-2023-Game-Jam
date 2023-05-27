using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    public int collideDamage;
    public int enemyHealth;

    PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerHealth.loseHealth(collideDamage);
        }
        else if (collision.gameObject.name == "Bullet(Clone)")
        {
            enemyHealth -= collideDamage;
        }
    }
}
