using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Clock : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;
    public GameObject secondHand;
    public TextMeshProUGUI timeText;
    MainTime mainTime;
    DayNightCycle dayNight;

    private void Start()
    {
        dayNight = DayNightCycle.ins;
        mainTime = dayNight.mainTime;
    }

    private void Update()
    {
        if (hourHand != null)
        {
            hourHand.transform.localRotation = Quaternion.Euler(hourHand.transform.localRotation.x, hourHand.transform.localRotation.y, (-mainTime.Hour * 30) - 90);
        }
        if (minuteHand != null)
        {
            minuteHand.transform.localRotation = Quaternion.Euler(minuteHand.transform.localRotation.x, minuteHand.transform.localRotation.y, (-mainTime.Minute * 6) - 90);
        }
        if (secondHand != null)
        {
            secondHand.transform.localRotation = Quaternion.Euler(secondHand.transform.localRotation.x, secondHand.transform.localRotation.y, (-mainTime.Second * 6) - 90);
        }
        if (timeText != null)
        {
            timeText.text = mainTime.TimeToString12();
        }
        
    }

}
