using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        HealthExtractor.instance.SetCondition(1);
        
        //Debug.Log("Over an enemy");
    }

    void OnMouseExit()
    {
        HealthExtractor.instance.SetCondition(0);

        //Debug.Log("Not over an enemy");
    }
}
