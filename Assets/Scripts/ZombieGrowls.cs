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

    IEnumerator Growling()
    {
        while (isGrowling) {
            float growlDelay = Random.Range(minGrowlDelay, maxGrowlDelay);
            yield return  new WaitForSeconds(growlDelay);

            float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
            growlAudioSource.clip = growlClips[Random.Range(0, growlClips.Length)];
            growlAudioSource.pitch = Random.Range(0.8f, 1.2f);
            growlAudioSource.volume = growlVolumeOverDistance.Evaluate(distanceFromPlayer);
            growlAudioSource.Play();
        }
    }

    public void StopGrowling()
    {
        isGrowling = false;
        growlAudioSource.Stop();
    }
}
