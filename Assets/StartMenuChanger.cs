using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuChanger : MonoBehaviour
{
    private void OnEnable()
    {
        ControlsManager.instance.ChangeControlMode(ControlsManager.ControlModes.StartOfGame);
    }
}
