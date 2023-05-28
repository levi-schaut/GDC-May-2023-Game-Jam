using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistExtract : MonoBehaviour
{
    ScientistCounter scientistCounter;

    private void Awake()
    {
        scientistCounter = GameObject.Find("Game Manager").GetComponent<ScientistCounter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        { 
            scientistCounter.scientistCount(1); 
            
            Destroy(this.gameObject);
        }
    }
}
