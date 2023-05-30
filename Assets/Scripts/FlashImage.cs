using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    public static FlashImage Instance { get; private set; }
    Image image = null;
    Coroutine currentFlash = null;

    private void Awake()
    {
        Instance = this;
        image = GetComponent<Image>();
    }

    public void StartFlash(float duration, float maxAlpha)
    {
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);
        if (currentFlash != null) 
            StopCoroutine(currentFlash);
        currentFlash = StartCoroutine(Flash(duration, maxAlpha));
    }

    IEnumerator Flash(float duration, float maxAlpha)
    {
        float halfDuration = duration / 2;
        for (float t = 0; t <= halfDuration; t += Time.deltaTime) {
            Color color = image.color;
            color.a = Mathf.Lerp(0, maxAlpha, t / halfDuration);
            image.color = color;
            yield return null;
        }
        for (float t = 0; t <= halfDuration; t += Time.deltaTime) {
            Color color = image.color;
            color.a = Mathf.Lerp(maxAlpha, 0, t / halfDuration);
            image.color = color;
            yield return null;
        }

        image.color = new Color32(255, 0, 0, 0);
    }
}
