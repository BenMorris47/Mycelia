using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SettingsManager : MonoBehaviour
{
    public CinemachineVirtualCamera cineVCam;
    [Header("Setting GameObjects")]
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown fullscreenModeDropdown;
    public Toggle vSyncToggle;
    public Slider fieldOfViewSlider;
    public Slider framesPerSecondSlider;

    [Header("Viewing Setting TextObjects")]
    public TextMeshProUGUI fieldOfViewSliderValueText;
    public TextMeshProUGUI framesPerSecondSliderValueText;

    [Header("Confirmation Box")]
    public GameObject confirmationPanel;

    [Header("UIManager")]
    public UIManager manager;
    CinemachinePOV cam;

    //Mouse Sensitivity
    float settingMouseSensX = 0.1f;
    float settingMouseSensY = 0.1f;
    //Other main vars, varName says all
    Resolution settingResolution;
    bool settingVSync;
    FullScreenMode settingFullscreenMode;
    int settingFramesPerSecond;
    int settingFieldOfView;
    
    //Mouse Sensitivity
    float startingMouseSensX = 0.1f;
    float startingMouseSensY = 0.1f;
    //Other main vars, varName says all
    Resolution startingResolution;
    bool startingVSync;
    FullScreenMode startingFullscreenMode;
    int startingFramesPerSecond;
    int startingFieldOfView;


    Dictionary<(int, int), string> resolutionPairs = new Dictionary<(int, int), string>() 
    { 
        { (1280, 720), "1280x720" }, //720p
        { (1920, 1080), "1920x1080" }, //1080p
        { (2560, 1440), "2560x1440" }, //1440p aka 2k
        { (3840, 2160), "3840x2160" }  //2160p aka 4k
    };

    float prevTimeScale = 1;

    private void OnEnable()
    {
        cam = cineVCam?.GetCinemachineComponent<CinemachinePOV>();
        SetupMenu();
        FirstRun();
    }

    private void FirstRun()
    {
        framesPerSecondSliderValueText.text = startingFramesPerSecond.ToString();
        fieldOfViewSliderValueText.text = startingFieldOfView.ToString();
        framesPerSecondSlider.value = startingFramesPerSecond;
        fieldOfViewSlider.value = startingFieldOfView;
        string resolution = Screen.currentResolution.ToString();

        for (int i = 0; i < resolutionDropdown.options.Count; i++)
        {
            if (resolutionDropdown.options[i].text == resolution)
            {
                resolutionDropdown.value = i;
            }
        }

    }

    private void Update()
    {
        if (Time.timeScale != prevTimeScale)
        {
            prevTimeScale = Time.timeScale;
            if (Time.timeScale == 0)
            {
                SetMouseSens(0, 0); 
            }
            else if (Time.timeScale == 1)
            {
                SetMouseSens(settingMouseSensX, settingMouseSensY);
            }
        }
    }

    [ContextMenu("TestRes")]
    public void SetupMenu()
    {
        int maxRefreshRate = 0;
        resolutionDropdown.options.Clear();
        fullscreenModeDropdown.options.Clear();

        foreach (var monitorRes in Screen.resolutions) //Getting highest refresh rate for the monitor
        {
            if (maxRefreshRate < monitorRes.refreshRate)
            {
                maxRefreshRate = monitorRes.refreshRate;
            }
        }
        foreach (var monitorRes in Screen.resolutions)
        {
            if (monitorRes.refreshRate == maxRefreshRate)
            {
                foreach (var sixteenNineRes in resolutionPairs)
                {
                    if (monitorRes.width == sixteenNineRes.Key.Item1 && monitorRes.height == sixteenNineRes.Key.Item2)
                    {
                        resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(monitorRes.ToString()));
                        break;
                    }
                }
            }
        }

        List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>()
        { 
            { new TMP_Dropdown.OptionData(FullScreenMode.ExclusiveFullScreen.ToString()) }, 
            { new TMP_Dropdown.OptionData(FullScreenMode.FullScreenWindow.ToString()) }, 
            { new TMP_Dropdown.OptionData(FullScreenMode.Windowed.ToString()) } 
        };

        fullscreenModeDropdown.options.AddRange(list);

        framesPerSecondSlider.maxValue = maxRefreshRate;
        framesPerSecondSliderValueText.text = framesPerSecondSlider.value.ToString();
        fieldOfViewSliderValueText.text = fieldOfViewSlider.value.ToString();


        startingMouseSensX = settingMouseSensX;
        startingMouseSensY = settingMouseSensY;
        startingResolution = settingResolution;
        startingVSync = settingVSync;
        startingFullscreenMode = settingFullscreenMode;
        startingFramesPerSecond = settingFramesPerSecond;
        startingFieldOfView = settingFieldOfView;

    }

    public void ConfirmMenu()
    {
        if (settingVSync != startingVSync || settingFullscreenMode != startingFullscreenMode || settingFramesPerSecond != startingFramesPerSecond || settingFieldOfView != startingFieldOfView || startingResolution.width != settingResolution.width)
        {
            Canvas oldCanvas = manager.currentCanvas;
            manager.EnableDisableCanvas(manager.videoCanvas);
            confirmationPanel.SetActive(true);
        }
    }
    public void FailMenu()
    {
        confirmationPanel.SetActive(false);
        manager.EnableDisableCanvas(manager.previousCanvas);
    }


    public void MouseSensX(float value)
    {
        settingMouseSensX = value;
    }
    public void MouseSensY(float value)
    {
        settingMouseSensY = value;
    }
    public void SetMouseSens(float mouseX, float mouseY)
    {
        if (cam != null)
        {
            cam.m_VerticalAxis.m_MaxSpeed = mouseX;
            cam.m_HorizontalAxis.m_MaxSpeed = mouseY;
        }
    }
    public void SetResolution(int value)
    {
        string res = resolutionDropdown.options[value].text;

        foreach (var monitorRes in Screen.resolutions)
        {
            if (monitorRes.ToString() == res)
            {
                settingResolution = monitorRes;
                return;
            }
        }
    }
    public void SetFullscreenMode(int value)
    {
        string mode = fullscreenModeDropdown.options[value].text;

        if (mode == FullScreenMode.ExclusiveFullScreen.ToString())
        {
            settingFullscreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else if (mode == FullScreenMode.FullScreenWindow.ToString())
        {
            settingFullscreenMode = FullScreenMode.FullScreenWindow;
        }
        else if (mode == FullScreenMode.Windowed.ToString())
        {
            settingFullscreenMode = FullScreenMode.Windowed;
        }
    }
    public void VSync(bool value)
    {
        Debug.Log(value);
        settingVSync = value;
    }
    public void FramesPerSecond(float value)
    {
        settingFramesPerSecond = (int)value;
        framesPerSecondSliderValueText.text = value.ToString();
    }
    public void FieldOfView(float value)
    {
        settingFieldOfView = (int)value;
        fieldOfViewSliderValueText.text = value.ToString();
    }

    public void ChangeSettings()
    {
        confirmationPanel.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("Successful change of settings");
#else 
        Screen.SetResolution(settingResolution.width, settingResolution.height, settingFullscreenMode);
        QualitySettings.vSyncCount = Convert.ToInt32(settingVSync);
        Application.targetFrameRate = settingFramesPerSecond;
        Camera.main.fieldOfView = settingFieldOfView;
#endif
        manager.EnableDisableCanvas(manager.previousCanvas);
    }
}
