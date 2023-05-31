using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    public Transform mainCamera;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin perlin;
    private float shakeTimer;

    private void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float duration)
    {
        perlin.m_AmplitudeGain = intensity;
        shakeTimer = duration;
    }

    private void Update()
    {
        if (shakeTimer > 0) {
            shakeTimer -= Time.deltaTime;
        }
        else {
            perlin.m_AmplitudeGain = 0f;
            mainCamera.rotation = Quaternion.identity;
        }
    }

    public void StopShaking()
    {
        shakeTimer = 0f;
        perlin.m_AmplitudeGain = 0f;
        mainCamera.rotation = Quaternion.identity;
    }
}
