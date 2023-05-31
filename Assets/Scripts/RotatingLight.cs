using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RotatingLight : MonoBehaviour
{
    public float rotationSpeed = 90f;
    
    Light2D light;


    private void Start()
    {
        light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }
}
