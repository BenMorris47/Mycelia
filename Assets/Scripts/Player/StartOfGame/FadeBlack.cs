using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeBlack : MonoBehaviour
{
    public Image backgroundPanel;
    public float fadeTime;

    UIManager manager;
    private void Start()
    {
        StartCoroutine(FadeBlackScreen(fadeTime));
        ControlsManager.instance.ChangeControlMode(ControlsManager.ControlModes.StartOfGame);
        manager = GameObject.FindObjectOfType<UIManager>();
    }
    public IEnumerator FadeBlackScreen(float fadeTime)
    {
        Time.timeScale = 0;
        float time = 0;
        Color baseColour = backgroundPanel.color;
        while (time <= fadeTime)
        {
            backgroundPanel.color = Color.Lerp(baseColour, new Color(0, 0, 0, 0), time / fadeTime);
            time += Time.unscaledDeltaTime;
            yield return null;
        }
        manager.OnCanvasChange(manager.playModeCanvas);
        Time.timeScale = 1; 
    }
}
