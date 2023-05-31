using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistExtract : MonoBehaviour
{
    ScientistIndicator scientistIndicator;

    private void Awake()
    {
        scientistIndicator = GameObject.FindGameObjectWithTag("In Game UI").GetComponent<ScientistIndicator>();
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
        if (collision.gameObject.tag == "Player")
        {
            scientistIndicator.number -= 1f;

            Destroy(this.gameObject);
        }
    }
}
