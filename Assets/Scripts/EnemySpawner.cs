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
    public float maxSpawnDistance;
    public float minSpawnDistance;
    public static EnemySpawner instance;

    private int currentEnemies = 0;
    int lastSpawnIndex = 999;


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

                int spawnAttempts = 0;

                while (!spawnPointFound && spawnAttempts < 5)
                {
                    int randomIndex = Random.Range(0, spawnLocations.Length);

                    if (randomIndex == lastSpawnIndex)
                        randomIndex = (randomIndex + 1) % spawnLocations.Length;

                    GameObject spawnPoint = spawnLocations[randomIndex];

                    float distance = Vector2.Distance(player.transform.position, spawnPoint.transform.position);

                    spawnAttempts++;

                    if (distance < maxSpawnDistance && distance > minSpawnDistance)
                    {

                        spawnPointFound = true;
                        Instantiate(enemy, spawnPoint.transform.position, transform.rotation);
                        currentEnemies++;
                        lastSpawnIndex = randomIndex;
                    }
                }
                if (!spawnPointFound)
                {
                    yield return null;
                }
                else
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }
        }
    }
}
