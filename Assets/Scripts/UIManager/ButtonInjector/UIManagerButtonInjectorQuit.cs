using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerButtonInjectorQuit : MonoBehaviour
{
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
        GetComponent<Button>().onClick.AddListener(() => Application.Quit());
    }
}
