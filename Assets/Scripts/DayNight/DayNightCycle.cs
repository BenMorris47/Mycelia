using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Main Settings")]
    [Tooltip("What day to start the game on")]
    public DayState startState = DayState.Morning;

    [Tooltip("The time needed for a full day/night cycle to occur (in seconds)")]
    public float secondsInFullCycle = 300f;

    [Tooltip("Tick this if you want time to actually move forward")]
    public bool increaseTime = true;

    [Tooltip("The main light of the scene aka the sun")]
    public Light mainLight;

    [Header("Skybox Colours")]
    [Tooltip("This is what the skybox will look like when it's dawn or dusk")]
    public SkyboxColour dawnDuskSkybox = new SkyboxColour(new Color(152, 152, 152), new Color(71, 75, 144), new Color(58, 58, 58));
    [Tooltip("This is what the skybox will look like when it's day")]
    public SkyboxColour daySkybox = new SkyboxColour(new Color(238, 238, 238), new Color(49, 89, 182), new Color(92, 58, 16));
    [Tooltip("This is what the skybox will look like when it's night")]
    public SkyboxColour nightSkybox = new SkyboxColour(new Color(122, 122, 144), new Color(38, 52, 141), new Color(0, 0, 0));

    [Header("Misc")]
    [Tooltip("This is the current time based on an actual clock")]
    public MainTime mainTime;
    public TextMeshProUGUI timeText;

    [Tooltip("The current time count in float form")]
    public float currentTimeInFloat = 0f;

    [Tooltip("The current day that the game is on")]
    public int currentDay = 0;

    public float rotation = 170;

    public GameObject moonOriginEmpty;

    public static DayNightCycle ins;

    private float startLightIntensity; //Holds the light's original intensity

    public DayState currentDateState = DayState.Morning; //The current time of day

    //Events
    public static Action OnSunRise;
    public static Action OnSunSet;
    public static Action OnMidday;
    public static Action OnMidnight;


    /* PROGRAMMER INSITE
     * When converting from the float to Time:
     * 0.0f = 00:00:00
     * 0.1f = 02:24:00
     * 0.2f = 04:48:00
     * 0.3f = 07:12:00
     * 0.4f = 09:36:00
     * 0.5f = 12:00:00
     * 0.6f = 14:24:00
     * 0.7f = 16:47:59
     * 0.8f = 19:12:00
     * 0.9f = 21:35:59
     * 1.0f = 24:00:00 aka 0.0f
     */
    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
    }

    void Start()
    {
        if (RenderSettings.ambientMode != UnityEngine.Rendering.AmbientMode.Trilight)
        {
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
        }

        startLightIntensity = mainLight.intensity;

        //This sets the time of day based off of the enum DayState
        switch (startState)
        {
            case DayState.Base:
                break;
            case DayState.Midnight:
                OnMidnight?.Invoke();
                currentTimeInFloat = 0.0f;
                break;
            case DayState.Morning:
                OnSunRise?.Invoke();
                currentTimeInFloat = 0.3f;
                break;
            case DayState.Midday:
                OnMidday?.Invoke();
                currentTimeInFloat = 0.5f;
                break;
            case DayState.Afternoon:
                currentTimeInFloat = 0.6f;
                break;
            case DayState.Evening:
                currentTimeInFloat = 0.7f;
                break;
            case DayState.Night:
                OnSunSet?.Invoke();
                currentTimeInFloat = 0.8f;
                break;
            default:
                break;
        }

    }

    void Update()
    {
        if (increaseTime)
        {
            currentTimeInFloat += (Time.deltaTime / secondsInFullCycle);

            mainTime.FloatToTime(currentTimeInFloat);

            //timeText.text = mainTime?.TimeToString12();

            SetTimeOfDayEnums();

            LightUpdate();
            CheckSkybox();

            if (currentTimeInFloat >= 1)
            {
                currentTimeInFloat = 0;
                currentDay++;
            }
        }
    }

	private void SetTimeOfDayEnums()
	{
        DayState newState = currentDateState;
		if (currentTimeInFloat <= 0.3f)
		{
            newState = DayState.Midnight;
        }
		else if (currentTimeInFloat <= 0.5f)
		{
            newState = DayState.Morning;
        }
        else if (currentTimeInFloat <= 0.6f)
        {
            newState = DayState.Midday;
        }
        else if (currentTimeInFloat <= 0.7f)
        {
            newState = DayState.Afternoon;
        }
        else if (currentTimeInFloat <= 0.8f)
        {
            newState = DayState.Evening;
        }
		else
		{
            newState = DayState.Night;
		}
   
		if (newState == currentDateState)
		{
            return;
		}
        currentDateState = newState;
        
        switch (currentDateState)
        {
            case DayState.Base:
                break;
            case DayState.Midnight:
                OnMidnight?.Invoke();
                break;
            case DayState.Morning:
                OnSunRise?.Invoke();
                break;
            case DayState.Midday:
                OnMidday?.Invoke();
                break;
            case DayState.Afternoon:
                break;
            case DayState.Evening:
                break;
            case DayState.Night:
                OnSunSet?.Invoke();
                break;
            default:
                break;
        }
    }

	void LightUpdate()
    {
        mainLight.transform.localRotation = Quaternion.Euler((currentTimeInFloat * 360f) - 90, rotation, 0);

        if (moonOriginEmpty != null)
        {
            moonOriginEmpty.transform.localRotation = Quaternion.Euler((currentTimeInFloat * 360f) - 100, rotation, 0);
        }

        float lightIntentsityMultiplier = 1f;

        if (mainTime <= new MainTime(5, 30, 0) || mainTime >= new MainTime(18, 0, 0)) //Before 5:30am and after 6pm
        {
            lightIntentsityMultiplier = 0f;
        }
        else if (mainTime <= new MainTime(6, 0, 0)) // Before 6am
        {
            lightIntentsityMultiplier = Mathf.Clamp01((currentTimeInFloat - 0.23f) * (1 / 0.02f));
        }
        else if (mainTime <= new MainTime(17, 30, 0)) // Before 5:30pm
        {
            lightIntentsityMultiplier = Mathf.Clamp01(1 - (currentTimeInFloat - 0.73f) * (1 / 0.02f));
        }

        mainLight.intensity = startLightIntensity * lightIntentsityMultiplier;
    }
    void CheckSkybox()
    {
        if (mainTime <= MainTime.Morning)
        {
            ChangeAmbientColours(nightSkybox);
        }
        if (mainTime > MainTime.Morning && mainTime < MainTime.Midday)
        {
            ChangeAmbientColours(dawnDuskSkybox);
        }
        if (mainTime > MainTime.Midday && mainTime < MainTime.Night)
        {
            ChangeAmbientColours(daySkybox);
        }
        if (mainTime > MainTime.Night)
        {
            ChangeAmbientColours(nightSkybox);
        }
    }

    void ChangeAmbientColours(SkyboxColour skyboxColour)
    {
        RenderSettings.ambientSkyColor = Color.Lerp(RenderSettings.ambientSkyColor, skyboxColour.skyboxColour, Time.deltaTime);
        RenderSettings.ambientEquatorColor = Color.Lerp(RenderSettings.ambientEquatorColor, skyboxColour.equatorColour, Time.deltaTime);
        RenderSettings.ambientGroundColor = Color.Lerp(RenderSettings.ambientEquatorColor, skyboxColour.horizonColour, Time.deltaTime);
    }
}
