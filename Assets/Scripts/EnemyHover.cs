using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHover : MonoBehaviour
{
    bool canHover = true;

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
        if (canHover)
            HealthExtractor.instance.SetEnemyHovered(gameObject);
        
        //Debug.Log("Over an enemy");
    }

    void OnMouseExit()
    {
        if (canHover)
            HealthExtractor.instance.SetNotHovered();

        //Debug.Log("Not over an enemy");
    }

    public void StopHovering()
    {
        canHover = false;
        HealthExtractor.instance.SetNotHovered();
    }
}
