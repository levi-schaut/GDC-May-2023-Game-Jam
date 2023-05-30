using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class MuzzleFlash : MonoBehaviour
{
    public float maxIntensity;
    public float duration;
    public float maxIntensityTimePoint;

    Light2D flashSource;
    Coroutine currentFlash;

    // Start is called before the first frame update
    void Awake()
    {
        flashSource = GetComponent<Light2D>();
        flashSource.intensity = 0f;
    }

    public void StartFlash()
    {
        if (currentFlash != null)
            StopCoroutine(currentFlash);
        currentFlash = StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        float lightUpDuration = duration * maxIntensityTimePoint;
        for (float t = 0; t <= lightUpDuration; t += Time.deltaTime) {
            flashSource.intensity = Mathf.Lerp(0, maxIntensity, t / lightUpDuration);
            yield return null;
        }

        float lightDownDuration = duration - lightUpDuration;
        for (float t = 0; t <= lightDownDuration; t += Time.deltaTime) {
            flashSource.intensity = Mathf.Lerp(maxIntensity, 0, t / lightDownDuration);
            yield return null;
        }

        flashSource.intensity = 0f;
    }
}
