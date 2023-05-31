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
    }

    void OnMouseExit()
    {
        HealthExtractor.instance.SetNotHovered();

        
    }

    public void StopHovering()
    {
        canHover = false;
        HealthExtractor.instance.SetNotHovered();
    }
}
