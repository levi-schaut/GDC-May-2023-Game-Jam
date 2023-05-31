using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightFlicker : MonoBehaviour
{
    public float flickerDelay = 5;
    public float highIntensity = 0.5f;
    public float lowIntensity = 0.25f;

    Light2D light;
    
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        flickerDelay += Random.Range(-1.0f, 1.0f);
        light.intensity = highIntensity;
        StartCoroutine(Flickering());
    }

    IEnumerator Flickering()
    {
        while (true) {
            yield return new WaitForSeconds(flickerDelay);

            float halfDuration = 0.15f;
            for (float t = 0; t <= halfDuration; t += Time.deltaTime) {
                light.intensity = Mathf.Lerp(highIntensity, lowIntensity, t/halfDuration);
                yield return null;
            }
            for (float t = 0; t <= halfDuration; t += Time.deltaTime) {
                light.intensity = Mathf.Lerp(lowIntensity, highIntensity, t / halfDuration);
                yield return null;
            }
        }
    }
}
