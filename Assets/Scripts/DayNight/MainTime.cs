using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MainTime
{
    [SerializeField]protected int hour;
    [SerializeField]protected int minute;
    [SerializeField]protected int second;

    public int Hour
    {
        get { return hour; }
    }
    public int Minute
    {
        get { return minute; }
    }
    public int Second
    {
        get { return second; }
    }

    #region DayStartRegions
    public static MainTime Morning
    {
        get { return new MainTime(2, 0, 0); }
    }

    public static MainTime Midday
    {
        get { return new MainTime(12, 0, 0); }
    }

    public static MainTime Evening
    {
        get { return new MainTime(16, 0, 0); }
    }

    public static MainTime Night
    {
        get { return new MainTime(19, 0, 0); }
    }
    public static MainTime Midnight
    {
        get { return new MainTime(0, 0, 0); }
    }
    #endregion

    #region Constructors
    public MainTime()
    {
        hour = 0;
        minute = 0;
        second = 0;
    }

    public MainTime(int hour, int minute, int second)
    {
        this.hour = Mathf.Clamp(hour, 0,23);
        this.minute = Mathf.Clamp(minute, 0, 59); 
        this.second = Mathf.Clamp(second, 0, 59);
    }

    public MainTime(int hour, int minute, int second, TimeDayEnum timeOfDay)
    {
        if (timeOfDay == TimeDayEnum.AM)
        {
            this.hour = Mathf.Clamp(hour, 0, 12);
            this.minute = Mathf.Clamp(minute, 0, 59);
            this.second = Mathf.Clamp(second, 0, 59);
        }
        else if (timeOfDay == TimeDayEnum.PM)
        {
            this.hour = Mathf.Clamp(hour + 12, 0, 23);
            this.minute = Mathf.Clamp(minute, 0, 59);
            this.second = Mathf.Clamp(second, 0, 59);
        }
    }

    #endregion

    /// <summary>
    /// Converts <paramref name="currentTime"/> to the hour, minute, second of this class 
    /// </summary>
    /// <param name="currentTime">The time in float you wish to convert to actual time</param>
    public void FloatToTime(float currentTime)
    {
        float tempHour = 24 * currentTime;
        float tempMinute = 60 * (tempHour - Mathf.Floor(tempHour));
        float tempSecond = 60 * (tempMinute - Mathf.Floor(tempMinute));
        hour = (int)tempHour;
        minute = (int)tempMinute;
        second = (int)tempSecond;
    }


    /// <summary>
    /// Resets the time to 0 (DEBUG ONLY)
    /// </summary>
    public void ResetTime()
    {
        hour = 0;
        minute = 0;
        second = 0;
    }
    #region AllTimeToString
    /// <summary>
    /// Converts the current hour, minute and second held in this class to a string of a 24 hour clock
    /// </summary>
    /// <returns>The current hour, minute and second in 24 hour format</returns>
    public string TimeToString24()
    {
        string hourStr = hour.ToString();
        string minStr = minute.ToString();
        string secStr = second.ToString();

        if (hourStr.Length == 1)
        {
            hourStr = hourStr.PadLeft(2, '0');
        }
        if (minStr.Length == 1)
        {
            minStr = minStr.PadLeft(2, '0');
        }
        if (secStr.Length == 1)
        {
            secStr = secStr.PadLeft(2, '0');
        }
        return $"{hourStr}:{minStr}:{secStr}";
    }

    /// <summary>
    /// Converts the current hour, minute and second held in this class to a string of a 12 hour clock
    /// </summary>
    /// <returns>The current hour, minute and second in 12 hour format</returns>
    public string TimeToString12()
    {
        string hourStr = hour.ToString();
        string minStr = minute.ToString();
        string secStr = second.ToString();


        if (hourStr.Length == 1)
        {
            hourStr = hourStr.PadLeft(2, '0');
        }
        if (minStr.Length == 1)
        {
            minStr = minStr.PadLeft(2, '0');
        }
        if (secStr.Length == 1)
        {
            secStr = secStr.PadLeft(2, '0');
        }

        if (hour < 12)
        {
            return $"{hourStr}:{minStr}:{secStr} AM";
        }
        else if (hour == 12)
        {
            return $"{hourStr}:{minStr}:{secStr} PM";
        }

        hourStr = (hour - 12).ToString();
        if (hourStr.Length == 1)
        {
            hourStr = hourStr.PadLeft(2, '0');
        }

        return $"{hourStr}:{minStr}:{secStr} PM";

    }
    #endregion

    #region TwoElementsToString
    /// <summary>
    /// Gets the hour and minute and returns it in a string
    /// </summary>
    /// <returns>The hour and minute variables in a string</returns>
    public string HourMinuteToString()
    {
        return $"{hour}{minute}";
    }
    /// <summary>
    /// Gets the hour and second and returns it in a string
    /// </summary>
    /// <returns></returns>
    public string HourSecondToString()
    {
        return $"{hour}{second}";
    }
    public string MinuteSecondToString()
    {
        return $"{minute}{second}";
    }
    #endregion
    /// <summary>
    /// Checks the current hour and returns the relevent DayState
    /// </summary>
    /// <returns>The relevent DayState based on the current hour</returns>
    public DayState TimeDayState()
    {
        if (this < Midnight && this < Morning) //12am - 2am
        {
            return DayState.Midnight;
        }
        else if (this > Morning && this < Midday) //2am - 12pm
        {
            return DayState.Morning;
        }
        else if (this > Midday && this < Evening) //12pm - 2pm
        {
            return DayState.Midday;
        }
        else if (this > Evening && this < Night) //2pm - 7pm
        {
            return DayState.Evening;
        }
        else if (this > Night && this < Midnight) //7pm - 12am
        {
            return DayState.Night;
        }
        return DayState.Base;
    }
    #region operatorOverloads
    public static bool operator >(MainTime left, MainTime right) //Left is bigger than right
    {
        if (left.hour > right.hour || left.hour >= right.hour && left.minute > right.minute || left.hour >= right.hour && left.minute >= right.minute && left.second > right.second)
        {
            return true;
        }
        return false;
    }

    public static bool operator <(MainTime left, MainTime right) //Right is bigger than left
    {
        if (right.hour > left.hour || right.hour >= left.hour && right.minute > left.minute || right.hour >= left.hour && right.minute >= left.minute && right.second > left.second)
        {
            return true;
        }

        return false;
    }

    public static bool operator >=(MainTime left, MainTime right) //Left is bigger or equal to left
    {
        if (left.hour > right.hour || left.hour >= right.hour && left.minute > right.minute || left.hour >= right.hour && left.minute >= right.minute && left.second >= right.second)
        {
            return true;
        }

        return false;
    }
    public static bool operator <=(MainTime left, MainTime right) //Right is bigger to equal to left
    {
        if (right.hour > left.hour || right.hour >= left.hour && right.minute > left.minute || right.hour >= left.hour && right.minute >= left.minute && right.second >= left.second)
        {
            return true;
        }

        return false;
    }
    #endregion

}

[System.Serializable]
public enum TimeDayEnum
{
    AM,
    PM,
}

[System.Serializable]
public enum DayState
{
    Base,
    Midnight,
    Morning,
    Midday,
    Afternoon,
    Evening,
    Night,
}

[System.Serializable]
public class SkyboxColour
{
    [Tooltip("The main skybox colour")]
    public Color skyboxColour;
    [Tooltip("The equator colour of the skybox")]
    public Color equatorColour;
    [Tooltip("The horizon colour of the skybox")]
    public Color horizonColour;

    public SkyboxColour(Color skyboxColour, Color equatorColour, Color horizonColour)
    {
        this.skyboxColour = skyboxColour;
        this.equatorColour = equatorColour;
        this.horizonColour = horizonColour;
    }

}
