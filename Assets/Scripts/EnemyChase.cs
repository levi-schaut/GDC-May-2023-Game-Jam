using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public float speed;             // Default speed of the zombie
    public float lightSpeedMultiplier;  // Multiplies to the speed whenever the zombie is in light
    public float detectionRange;    // Distance at which the zombie will detect the player
    
    private float distance;         
    private GameObject player;
    private int numLightsIn = 0;    // The number of lights the zombie is currently in.

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < detectionRange)
        {
            float currentSpeed;
            if (numLightsIn > 0)
            {
                currentSpeed = speed * lightSpeedMultiplier;
            }
            else
            {
                currentSpeed = speed;
            }
            rb.velocity = direction * currentSpeed;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            EnemySpawner.instance.EnemyDied();

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LightSource") {
            numLightsIn++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "LightSource") {
            numLightsIn--;
        }
    }
}
