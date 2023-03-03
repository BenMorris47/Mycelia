using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineInputProviderXYAxis : MonoBehaviour
{
    CinemachinePOV cam;

    [SerializeField]float xAxisSensitivity = 0.1f;
    [SerializeField]float yAxisSensitivity = 0.1f;
    float prevTimeScale = 1;

    void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();
    }
    private void Update()
    {
        if (Time.timeScale != prevTimeScale)
        {
            prevTimeScale = Time.timeScale;
            if (Time.timeScale == 0)
            {
                ChangeSensitivity(0, 0);
            }
            else if (Time.timeScale == 1)
            {
                ChangeSensitivity(xAxisSensitivity, yAxisSensitivity);
            }
        }
    }


    public void SetXSensitivity(float value)
    {
        xAxisSensitivity = value;
    }
    public void SetYSensitivity(float value)
    {
        yAxisSensitivity = value;
    }
    private void ChangeSensitivity(float x, float y)
    {
        cam.m_VerticalAxis.m_MaxSpeed = x;
        cam.m_HorizontalAxis.m_MaxSpeed = y;
    }
}
