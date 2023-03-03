using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerButtonInjectorControlModeChange : MonoBehaviour
{
    public UIManager manager;
    public ControlsManager.ControlModes controlMode;
    bool calledOnce = false;
    private void OnEnable()
    {
        if (!calledOnce)
        {
            Inject();
            calledOnce = true;
        }
    }

    public void Inject()
    {
        GetComponent<Button>().onClick.AddListener(() => ControlsManager.instance.ChangeControlMode(controlMode));
    }
}
