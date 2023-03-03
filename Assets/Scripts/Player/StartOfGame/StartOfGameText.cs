using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartOfGameText : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI textbox;
    [Header("Text Shown On Screen Variables")]
    [TextArea]public string[] textToShow;
    public float durationForNextLetterToShow;

    private int curStringText = 0;
    private Coroutine textShowRoutine;
    private void OnEnable()
    {
        textShowRoutine = StartCoroutine(DisplayText(textToShow[curStringText], durationForNextLetterToShow));
    }
    private void OnDestroy()
    {
        ControlsManager.instance.controls.StartGameText.ProgressSkip.performed -= context => SkipText();
    }

    private void Start()
    {
        ControlsManager.instance.controls.StartGameText.Enable();
        ControlsManager.instance.controls.StartGameText.ProgressSkip.performed += context => SkipText();
    }
    private void SkipText()
    {
        if (textbox.text != textToShow[curStringText] && textbox.text != (textToShow[curStringText] + "\n>"))
        {
            StopCoroutine(textShowRoutine);
            textbox.text = textToShow[curStringText];
            textShowRoutine = StartCoroutine(TextEnd());
        }
        else
        {
            StopCoroutine(textShowRoutine);
            if (textToShow.Length > curStringText+1)
            {
                curStringText++;
                textShowRoutine = StartCoroutine(DisplayText(textToShow[curStringText], durationForNextLetterToShow));
            }
            else
            {
                GetComponent<UIManagerButtonInjectorSceneChange>().ChangeSceneTo();
                //textShowRoutine = StartCoroutine(FadeBlackScreen(blackScreenFadeTime));
            }
        }
    }

    private IEnumerator TextEnd()
    {
        float time = 0;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/UI/General/UI_TextBlip2");
        textbox.text += "\n>";
        while (time < 0.2)
        {
            time += Time.unscaledDeltaTime;
            yield return null;
        }
        time = 0;
        textbox.text = textToShow[curStringText];
        while (time < 0.2)
        {
            time += Time.unscaledDeltaTime;
            yield return null;
        }
        textShowRoutine = StartCoroutine(TextEnd());
    }

    public IEnumerator DisplayText(string textToDisplay, float duration)
    {
        textbox.text = null;
        float time = 0;
        int charCount = 0;
        do
        {
            if (textToDisplay[charCount] != ' ')
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/UI/General/UI_TextBlip");
            }
            else if (textToDisplay[charCount] == ' ')
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/UI/General/UI_TextBlipSpace");
            }
            textbox.text += textToDisplay[charCount];
            charCount++;
            while (time <= duration) { time += Time.unscaledDeltaTime; yield return null; }
            time = 0;
        } while (textbox.text != textToDisplay);
        textShowRoutine = StartCoroutine(TextEnd());

    }   

   


    /*
      Welcome scientist number 64209 to the [INSERT NAME] COMPANY. You have been sent with your fellow scientist colleagues to our species’ old home, Earth. 
      As you are aware, after the fungal outbreak our old home has been deemed inhabitable which led us to flee the planet. 
     * 
      However, Professor [INSERT NAME] believes that after years of mutation these fungi can benefit humanity. This is where you come in. 
      Your mission is to go back to earth and research this fungus. You must photograph, document, collect, test, and report your findings. 
     * 
      We will provide you with all the necessary tools you require. The specific location you are assigned to is Gunkanjima island. 
     * 
      Good luck scientist number 64209.
     */
}
