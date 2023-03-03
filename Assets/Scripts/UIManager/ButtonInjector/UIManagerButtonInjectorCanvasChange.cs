using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerButtonInjectorCanvasChange : MonoBehaviour
{
    public UIManager manager;
    public Canvas canvasToEnable;
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
        GetComponent<Button>().onClick.AddListener(() => manager.EnableDisableCanvas(canvasToEnable));
    }
}
