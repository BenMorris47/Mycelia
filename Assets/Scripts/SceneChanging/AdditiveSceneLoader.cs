using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour
{
    public Scenes sceneToChangeTo;
    public Scenes[] sceneToChangeToAdditive;
    public void ChangeSceneTo()
    {

        SceneManager.LoadScene(sceneToChangeTo.ToString());
        foreach (var scene in sceneToChangeToAdditive)
        {
            SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
        }
    }



    //**THIS NEEDS TO BE UPDATED WHENEVER A NEW SCENE IS ADDED TO THE BUILD SETTINGS**//
    [System.Serializable]
    public enum Scenes
    {
        SCN_StartMenu,
        SCN_Island,
        SCN_FinishDemo,
        SCN_Player,
        SCN_LevelTransitions,
        SCN_BaseMeshTest
    }
}
