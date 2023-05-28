using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    public float radius = 5f;
    public float distancePercentage = 0.5f;
    public float smoothTime = 0.1f;

    private Vector3 velocity = Vector3.zero;

    public void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 newPosition = new Vector3(
          (mousePosition.x - playerTransform.position.x) * distancePercentage + playerTransform.position.x,
          (mousePosition.y - playerTransform.position.y) * distancePercentage + playerTransform.position.y,
          transform.position.z
        );

        float dist = Vector2.Distance(
          new Vector2(newPosition.x, newPosition.y),
          new Vector2(playerTransform.position.x, playerTransform.position.y)
        );

        if (dist > radius) {
            Vector3 mouseOffset = mousePosition - playerTransform.position;
            var mouseOffsetNorm = mouseOffset.normalized;
            newPosition = new Vector3(
              mouseOffsetNorm.x * radius + playerTransform.position.x,
              mouseOffsetNorm.y * radius + playerTransform.position.y,
              transform.position.z
            );
        }
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}

