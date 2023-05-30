using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    // public bool stopSpawning;
    public float spawnTime;
    public float spawnDelay;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.transform.position.y);

        if (player.transform.position.y > 3)
        {
            //stopSpawning = true;

            this.enabled = false;
        }
        else
        {
            //stopSpawning = false;

            this.enabled = true;
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        
        /*if (stopSpawning)
        {
            CancelInvoke("SpawnEnemy");
        }*/

        
    }
}
