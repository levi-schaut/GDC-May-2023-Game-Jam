using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float verticalSpeed = 15f;
    public float horizontalSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float v = verticalSpeed * Input.GetAxis("Vertical");
        float h = horizontalSpeed * Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(h, v) * Time.deltaTime); 
    }
}
