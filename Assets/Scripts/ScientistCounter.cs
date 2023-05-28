using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistCounter : MonoBehaviour
{
    public int scientistsExtracted;

    private void Awake()
    {   
        scientistsExtracted = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scientistCount(int amount)
    {
        scientistsExtracted += amount;
    }
}
