using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthExtractor : MonoBehaviour
{
    public static HealthExtractor instance;
    public PlayerHealth playerHealth;
    public int extractAmount;
    public float extractDuration;
    [SerializeField] float extractCooldown;
    public UIExtractorCooldown UIExtractorScript;

    public Sprite playerWithHealthExtractor;


    int currentCondition;
    // 0 = can't extract
    // 1 = can extract


    EnemyCollide enemyCollide;
    ParticleSystem healthExtrationParticles;
    private bool canExtract;


    private void Awake()
    {
        instance = this;

        //playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyCollide = enemy.GetComponent<EnemyCollide>();
        healthExtrationParticles = enemy.GetComponentInChildren<ParticleSystem>();

        currentCondition = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        canExtract = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentCondition == 1 && canExtract)
        {
            StartCoroutine(ExtractionInProgress());
            //UIExtractorScript.StartRecharging(extractCooldown);
            StartCoroutine(ExtractWait());
        }
        
        //Debug.Log(currentCondition);
    }

    public void SetCondition (int condition)
    {
        currentCondition = condition;
    }

    IEnumerator ExtractionInProgress()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = playerWithHealthExtractor;
        canExtract = false;
        healthExtrationParticles.Play();
        //playerHealth.gainHealth(extractAmount);
        enemyCollide.enemyHealth -= extractAmount;

        yield return new WaitForSeconds(extractDuration);

        healthExtrationParticles.Stop();
    }

    IEnumerator ExtractWait()
    {
        yield return new WaitForSeconds(extractCooldown);
        canExtract = true;
    }
}
