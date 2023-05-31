using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            if (numLightsIn > 0) {
                currentSpeed = speed * lightSpeedMultiplier;
            } else {
                currentSpeed = speed;
            }
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, currentSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            EnemySpawner.instance.EnemyDied();

            Debug.Log("Despawned Enemy");

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
