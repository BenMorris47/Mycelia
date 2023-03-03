using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerButtonInjectorSceneChange : MonoBehaviour
{
    public string sceneName = "SCN_BaseMeshTest";
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
        //GetComponent<Button>().onClick.AddListener(ChangeSceneTo);
    }

    public void ChangeSceneTo()
    {

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
