using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class CameraScript : MonoBehaviour
{

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeIntensity = 1f;
    private float shakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    void Start()
    {
        shakeStop();
    }

    void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void shakeCamera()
    {
        _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = shakeIntensity;

        timer = shakeTime;
    }
    public void shakeStop()
    {
        _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;

        timer = 0f;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            shakeCamera();
        }

        if(timer  > 0f)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                shakeStop();

            }
            
        }
    }
}
