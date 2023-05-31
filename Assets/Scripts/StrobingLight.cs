using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class StrobingLight : MonoBehaviour
{
    public float highIntensity = 1.0f;
    public float lowIntensity = 0.0f;
    public float range = 10f;
    public float strobeDuration = 1f;

    Light2D light;

    private void Start()
    {
        light = GetComponent<Light2D>();
        StartCoroutine(Strobing());
    }

    IEnumerator Strobing()
    {
        while (true) {
            float halfDuration = strobeDuration / 2f;
            for (float t = 0; t <= halfDuration; t += Time.deltaTime) {
                light.intensity = Mathf.Lerp(highIntensity, lowIntensity, t / halfDuration);
                yield return null;
            }
            for (float t = 0; t <= halfDuration; t += Time.deltaTime) {
                light.intensity = Mathf.Lerp(lowIntensity, highIntensity, t / halfDuration);
                yield return null;
            }
        }
    }
}
