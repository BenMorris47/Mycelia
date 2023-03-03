using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionOnStart : MonoBehaviour
{
    Dictionary<(int, int), string> resolutionPairs = new Dictionary<(int, int), string>()
    {
        { (1280, 720), "1280x720" }, //720p
        { (1920, 1080), "1920x1080" }, //1080p
        { (2560, 1440), "2560x1440" }, //1440p aka 2k
        { (3840, 2160), "3840x2160" }  //2160p aka 4k
    };

    // Start is called before the first frame update
    void Start()
    {
        Resolution startRes = Screen.currentResolution;
        Resolution maxRes = new Resolution();
        foreach (Resolution res in Screen.resolutions)
        {
            foreach (var resPair in resolutionPairs)
            {
                if (res.width == resPair.Key.Item1 && res.height == resPair.Key.Item2)
                {
                    if (maxRes.width < res.width && maxRes.height < res.height)
                    {
                        maxRes = res;
                        break;
                    }
                }
            }
        }
        if (startRes.width != maxRes.width && startRes.height != maxRes.height)
        {
            Screen.SetResolution(maxRes.width, maxRes.height, true);
        }


    }
}
