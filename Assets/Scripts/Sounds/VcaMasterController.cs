using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VcaMasterController : MonoBehaviour
{
    public TextMeshProUGUI volumeText;
    private FMOD.Studio.VCA MasterVca;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        MasterVca = FMODUnity.RuntimeManager.GetVCA("vca:/Master");
        slider = GetComponent<Slider>();
    }

    public void SetVolume(float volume)
    {
        MasterVca.setVolume(volume / 100);
        volumeText.text = $"{volume}";
    }
}