using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    public Transform player;
    public Transform exitLocation;
    public AnimationCurve alarmVolumeCurve;

    AudioSource alarmSource;

    private void OnEnable()
    {
        alarmSource = GetComponent<AudioSource>();
        alarmVolumeCurve.postWrapMode = WrapMode.ClampForever;
        alarmSource.Play();
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, exitLocation.position);
        alarmSource.volume = alarmVolumeCurve.Evaluate(distance);
    }
}
