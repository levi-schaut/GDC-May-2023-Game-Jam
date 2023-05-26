using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] AnimationCurve acceleration;
    [SerializeField] float accelerationDuration;
    [SerializeField] AnimationCurve deceleration;
    [SerializeField] float decelerationDuration;
    private Vector2 lastDirection;
    private float timePass = 0;
    private float currentSpeed;

    Rigidbody2D rb;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            // Store last direction player moved in
            lastDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // Accelerate player
            timePass += Time.deltaTime;
            float linearT = timePass / accelerationDuration;
            float heightT = acceleration.Evaluate(linearT);
            currentSpeed = Mathf.Lerp(0, 4, heightT);
            lastDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else
        {
            // Time doesn't go over deceleration duration
            if (timePass > decelerationDuration)
            {
                timePass = decelerationDuration;
            }

            // Time doesn't go below 0
            if (timePass <= 0)
            {
                timePass = 0;
            }
            else
            {
                // Decelerate player
                timePass -= Time.deltaTime;
                float linearT = timePass / decelerationDuration;
                float heightT = deceleration.Evaluate(linearT);
                currentSpeed = Mathf.Lerp(0, 4, heightT);
                direction = lastDirection;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction.normalized * Time.fixedDeltaTime * currentSpeed * speed);
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}
