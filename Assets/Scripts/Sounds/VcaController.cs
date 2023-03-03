using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using TMPro;

public class VcaController : MonoBehaviour
{
    private VCA VcaControl;
    public string vcaName;
    public TextMeshProUGUI screenText;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        if (vcaName != null)
        {
            VcaControl = FMODUnity.RuntimeManager.GetVCA("vca:/" + vcaName);
        }
        slider = GetComponent<Slider>();
    }

    public void SetVolume(float volume)
    {
        VcaControl.setVolume(volume / 100);
        screenText.text = volume.ToString();
    }
}