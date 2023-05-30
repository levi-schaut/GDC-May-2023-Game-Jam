using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIExtractorCooldown : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;

    private int spriteIndex;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        if (image == null) {
            Debug.Log("No image found");
        }
        spriteIndex = sprites.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        //spriteIndex = (spriteIndex + 1) % sprites.Length;
        //image.sprite = sprites[spriteIndex];
    }

    public void StartRecharging(float seconds)
    {
        StartCoroutine(Recharge(seconds));
    }

    IEnumerator Recharge(float seconds)
    {
        spriteIndex = 0;
        while (spriteIndex < sprites.Length) {
            image.sprite = sprites[spriteIndex];
            yield return new WaitForSeconds(seconds / sprites.Length);
            spriteIndex++;
        }
        spriteIndex = sprites.Length - 1;
    }
}
