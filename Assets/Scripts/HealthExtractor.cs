using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthExtractor : MonoBehaviour
{
    public static HealthExtractor instance;
    public PlayerHealth playerHealth;
    public int extractAmount;
    [SerializeField] float extractCooldown;
    public UIExtractorCooldown uiExtractorScript;


    int currentCondition;
    // 0 = can't extract
    // 1 = can extract


    EnemyCollide enemyCollide;
    private bool canExtract;


    private void Awake()
    {
        instance = this;

        //playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        enemyCollide = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCollide>();

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
            playerHealth.gainHealth(extractAmount);

            enemyCollide.enemyHealth -= extractAmount;

            canExtract = false;
            uiExtractorScript.StartRecharging(extractCooldown);
            StartCoroutine(extractWait());
        }
        
        //Debug.Log(currentCondition);
    }

    public void SetCondition (int condition)
    {
        currentCondition = condition;
    }

    IEnumerator extractWait()
    {
        yield return new WaitForSeconds(extractCooldown);
        canExtract = true;
    }
}
