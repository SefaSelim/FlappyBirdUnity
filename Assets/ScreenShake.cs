using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;

    public static ScreenShake Instance { get; private set; } 

    private void Awake()
    {
        Instance = this;
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void Shake(float intensity, float time)
    {
        CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
        shakeTimer = time;
        shakeTimerTotal = time;
        startingIntensity = intensity;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            float lerpAmount = 1 - (shakeTimer / shakeTimerTotal);
            float currentIntensity = Mathf.Lerp(startingIntensity, 0f, lerpAmount);

            CinemachineBasicMultiChannelPerlin perlin = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlin.m_AmplitudeGain = currentIntensity;
        }
    }
}
