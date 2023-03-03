using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSoundPlayer : MonoBehaviour
{
    
    public FMODUnity.EventReference sound;
    public void PlaySound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(sound);
    }
   
}
