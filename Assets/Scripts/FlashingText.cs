using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashingText : MonoBehaviour
{
    TMP_Text text;

    void OnEnable()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine(FlashRedWhite());
    }

    IEnumerator FlashRedWhite()
    {
        while (true) {
            text.color = Color.white;
            yield return new WaitForSeconds(1);
            text.color = Color.red;
            yield return new WaitForSeconds(1);
        }
    }
}
