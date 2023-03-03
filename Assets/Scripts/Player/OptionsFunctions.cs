using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class OptionsFunctions : MonoBehaviour
{
    bool paused = false;
    private void OnEnable()
    {
        ControlsManager.instance.controls.ConstantControls.Pause.performed += context => ChangeOptions();
    }

    private void OnDisable()
    {
        ControlsManager.instance.controls.ConstantControls.Pause.performed -= context => ChangeOptions();
    }

    private void ChangeOptions()
    {
        if (!paused)
        {
            ControlsManager.instance.ChangeControlMode(ControlsManager.ControlModes.Pause);
            paused = true;
        }
        else
        {
            ControlsManager.instance.ChangeControlMode(ControlsManager.ControlModes.PlayMode);
            paused = false;
        }
    }
}
