using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Sprite deadSprite;
    public float secondsToDisappear = 5;

    EnemyChase chase;
    EnemyCollide collide;
    EnemyHover hover;
    ZombieGrowls growls;
    SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        chase = GetComponent<EnemyChase>();
        collide = GetComponent<EnemyCollide>();
        hover = GetComponent<EnemyHover>();
        growls = GetComponent<ZombieGrowls>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Die()
    {
        chase.StopChasing();
        collide.StopColliding();
        hover.StopHovering();
        growls.StopGrowling();

        spriteRenderer.sprite = deadSprite;
        StartCoroutine(WaitToDisappear());
    }

    IEnumerator WaitToDisappear()
    {
        yield return new WaitForSeconds(secondsToDisappear);
        Destroy(this.gameObject);
    }
}
