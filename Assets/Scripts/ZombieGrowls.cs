using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGrowls : MonoBehaviour
{
    public float minGrowlDelay;
    public float maxGrowlDelay;
    public AnimationCurve growlVolumeOverDistance;
    public AudioSource growlAudioSource;
    public AudioClip[] growlClips;

    private GameObject player;
    private bool isGrowling = true;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Growling());
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        growlAudioSource.volume = growlVolumeOverDistance.Evaluate(distanceFromPlayer);
    }

    IEnumerator Growling()
    {
        while (isGrowling) {
            growlAudioSource.clip = growlClips[Random.Range(0, growlClips.Length)];
            growlAudioSource.pitch = Random.Range(0.8f, 1.2f);
            growlAudioSource.Play();

            float growlDelay = Random.Range(minGrowlDelay, maxGrowlDelay);
            yield return new WaitForSeconds(growlDelay);
        }
    }

    public void StopGrowling()
    {
        isGrowling = false;
        growlAudioSource.Stop();
    }
}
