using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    public int collideDamage;
    public int enemyHealth;
    public AudioSource hitPlayerAudioSource;
    public AudioSource gotHitAudioSource;
    public AudioClip[] gotHitSoundClips;

    PlayerHealth playerHealth;
    EnemyDeath deathScript;

    bool canCollide = true;

    private void Awake()
    {
        //playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        deathScript = GetComponent<EnemyDeath>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            EnemySpawner.instance.EnemyDied();
            deathScript.Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canCollide) {
            if (collision.gameObject.tag == "Player")
            {
                hitPlayerAudioSource.pitch = Random.Range(0.8f, 1.2f);
                hitPlayerAudioSource.Play();
                CinemachineShake.Instance.ShakeCamera(2f, 0.2f);
                FlashImage.Instance.StartFlash(0.25f, 0.5f);
                playerHealth.loseHealth(collideDamage);
            }
            else if (collision.gameObject.tag == "PlayerProjectile")
            {
                gotHitAudioSource.pitch = Random.Range(0.8f, 1.2f);
                int randomIndex = Random.Range(0, gotHitSoundClips.Length);
                gotHitAudioSource.clip = gotHitSoundClips[randomIndex];
                gotHitAudioSource.Play();
                enemyHealth -= collideDamage;
            }
        }
    }

    public void StopColliding()
    {
        canCollide = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
