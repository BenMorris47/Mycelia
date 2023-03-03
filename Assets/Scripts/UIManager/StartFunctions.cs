using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class StartFunctions : MonoBehaviour
{
    public bool rotate;
    public float rotationSpeed;
    public SceneName sceneName;
    public string nameScene;
    public TMP_Dropdown dropdown;
    public GameObject startCanvas;
    public GameObject sceneSelectionCanvas;

    private void OnEnable()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    public void Resume()
    {
        ControlsManager.instance.ChangeControlMode(ControlsManager.ControlModes.PlayMode);
    }
    public void LoadScene(int enumSceneName)
    {
        sceneName = (SceneName)enumSceneName;
        SceneManager.LoadScene(sceneName.ToString());
    }
    public void LoadScene(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
    }
    

    public void ChangeCanvas()
    {
        startCanvas.SetActive(!startCanvas.activeSelf);
        sceneSelectionCanvas.SetActive(!sceneSelectionCanvas.activeSelf);
    }
    public void LoadDropdown()
    {
        SceneManager.LoadScene(dropdown.value);
    }

    public void Quit()
    {
#if !UNITY_EDITOR
        Application.Quit();
#endif
        Debug.Log("Quit!");
    }

    [System.Serializable]
    public enum SceneName
    {
        StartMenu,
        DayNightExample,
        SCN_BuildScene,
    }
}
