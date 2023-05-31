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
        Debug.Log("Over an enemy");

        HealthExtractor.instance.SetHoveredEnemy(gameObject);
        
        
    }

    void OnMouseExit()
    {
        Debug.Log("Not over an enemy");

        HealthExtractor.instance.SetNotHovered();

        
    }
}
