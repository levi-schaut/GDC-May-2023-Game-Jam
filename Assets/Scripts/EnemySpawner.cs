using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    GameObject player;

    public float waitTime;

    public GameObject[] spawnLocations;

    public bool canSpawn = true;

    public int maxEnemies;

    private int currentEnemies = 0;

    public float maxSpawnDistance;

    public static EnemySpawner instance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutine());
    }

    public void EnemyDied()
    {
        currentEnemies--;
    }

    IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            if (currentEnemies >= maxEnemies)
            {
                yield return null;
            }
            else
            {

                bool spawnPointFound = false;
                Debug.Log("Searching for spawn points");

                int spawnAttempts = 0;

                while (!spawnPointFound && spawnAttempts < 5)
                {
                    int randomIndex = Random.Range(0, spawnLocations.Length);

                    GameObject spawnPoint = spawnLocations[randomIndex];

                    float distance = Vector2.Distance(player.transform.position, spawnPoint.transform.position);

                    spawnAttempts++;

                    if (distance < maxSpawnDistance)
                    {

                        spawnPointFound = true;
                        Instantiate(enemy, spawnPoint.transform.position, transform.rotation);
                        currentEnemies++;
                    }
                }
                if (!spawnPointFound)
                {
                    yield return null;
                }
                else
                {
                    Debug.Log("Enemy Spawned");
                    yield return new WaitForSeconds(waitTime);
                }
            }
        }
    }
}
