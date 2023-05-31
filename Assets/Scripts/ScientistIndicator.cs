using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScientistIndicator : MonoBehaviour
{
    public TMP_Text indicatorText;
    public float number;
    public TMP_Text returnToExitText;
    public GameObject winZone;

    // Start is called before the first frame update
    void Start()
    {
        number = 3f;
        indicatorText.text = "Scientists Left to Rescue: " + number.ToString();
        returnToExitText.gameObject.SetActive(false);
        winZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        indicatorText.text = "Scientists Left to Rescue: " + number.ToString();
        if (number < 1) {
            returnToExitText.gameObject.SetActive(true);
            winZone.SetActive(true);
        }
    }
}
