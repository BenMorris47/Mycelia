using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;

public class UIManager : MonoBehaviour
{

    [Header("Canvas'")]
    [HideInInspector] public List<Canvas> canvases;
    public Canvas startGameCanvas;
    public Canvas playModeCanvas;
    public Canvas photoModeCanvas;
    public Canvas journalModeCanvas;
    public Canvas emailCanvas;
    public Canvas pauseCanvas;
    public Canvas settingsCanvas;
    public Canvas videoCanvas;
    public Canvas controlsCanvas;
    public Canvas soundCanvas;
    public Canvas historyCanvas;
    public Canvas debugCanvas;

    [HideInInspector] public Canvas currentCanvas;
    [HideInInspector] public Canvas previousCanvas;

    bool uiOpen = false;

    private void OnValidate()
    {
        //This gets all variables within this script, gets the Canvas' and dynamically adds them to canvases, this saves us manually doing it.
        Type getType = this.GetType();
        FieldInfo[] getField = getType.GetFields();
        List<FieldInfo> canvasFields = getField.Where(field => field.FieldType == typeof(Canvas)).ToList();
        canvases = canvasFields.Select(field => (Canvas)field.GetValue(this)).ToList();
    }

    private void OnEnable()
    {
        ControlsManager.instance.controls.ConstantControls.Pause.performed += context => OnCanvasChange(settingsCanvas);
        ControlsManager.instance.controls.TabletShortcuts.Journal.performed += context => OnCanvasChange(journalModeCanvas);
        ControlsManager.instance.controls.History.HistoryActivation.performed += context => OnCanvasChange(historyCanvas);
    }
    private void OnDisable()
    {
        ControlsManager.instance.controls.ConstantControls.Pause.performed -= context => OnCanvasChange(settingsCanvas);
        ControlsManager.instance.controls.TabletShortcuts.Journal.performed -= context => OnCanvasChange(journalModeCanvas);
        ControlsManager.instance.controls.History.HistoryActivation.performed -= context => OnCanvasChange(historyCanvas);
    }

    public void OnCanvasChange(Canvas canvasToEnable)
    {
        
        if (uiOpen && canvasToEnable == pauseCanvas || previousCanvas == canvasToEnable)
        {
            EnableDisableCanvas(playModeCanvas);
        }
        else
        {
            EnableDisableCanvas(canvasToEnable);
        }
    }

    public void EnableDisableCanvas(Canvas canvasToEnable)
    {
        List<Canvas> parentCanvases = ParentCanvas(canvasToEnable);

        foreach (Canvas canvas in canvases)
        {
            if (canvas != null)
            {
                if (canvas == canvasToEnable)
                {
                    foreach (var parentCanvas in parentCanvases)
                    {
                        if (!parentCanvas.gameObject.activeInHierarchy)
                        {
                            parentCanvas.gameObject.SetActive(true);
                        }
                    }
                    if (!canvas.gameObject.activeInHierarchy)
                    {
                        canvas.gameObject.SetActive(true);
                    }
                    previousCanvas = currentCanvas;
                    currentCanvas = canvasToEnable;
                }
                else
                {
                    if (canvas.gameObject.activeInHierarchy)
                    {
                        bool canvasIsParentCanvas = false;

                        foreach (var parentCanvas in parentCanvases)
                        {
                            if (parentCanvas == canvas)
                            {
                                canvasIsParentCanvas = true;
                            }
                        }
                        
                        if (!canvasIsParentCanvas)
                        {
                            canvas.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        if (canvasToEnable != playModeCanvas && canvasToEnable != photoModeCanvas)
        {
            uiOpen = true;
        }
        else
        {
            uiOpen = false;
        }

        ControlModeChange(canvasToEnable);

        if (canvasToEnable == emailCanvas)
        {
            EmailManager.instance.uiManager.EmailPreviewSetup();
        }
        if (previousCanvas == videoCanvas && !videoCanvas.gameObject.activeInHierarchy)
        {
            GameObject.FindObjectOfType<SettingsManager>().ConfirmMenu();
        }
        else if (canvasToEnable == videoCanvas)
        {
            GameObject.FindObjectOfType<SettingsManager>().SetupMenu();
        }


    }

    private void ControlModeChange(Canvas controlModeCanvas)
    {
        if (controlModeCanvas == playModeCanvas)
        {
            if (ControlsManager.instance.currentMode != ControlsManager.ControlModes.PlayMode)
            {
                ControlsManager.instance.ChangeControlMode(ControlsManager.ControlModes.PlayMode);
                Time.timeScale = 1;
            }

        }
        else if (controlModeCanvas == photoModeCanvas)
        {
            if (ControlsManager.instance.currentMode != ControlsManager.ControlModes.PhotoMode)
            {
                ControlsManager.instance.ChangeControlMode(ControlsManager.ControlModes.PhotoMode);
                Time.timeScale = 1;
            }
        }
        else
        {
            if (ControlsManager.instance.currentMode != ControlsManager.ControlModes.Pause)
            {
                ControlsManager.instance.ChangeControlMode(ControlsManager.ControlModes.Pause);
                Time.timeScale = 0;
            }
        }
    }

    private List<Canvas> ParentCanvas(Canvas canvas)
    {
        List<Canvas> parentCanvases = new List<Canvas>();

        if (canvas.transform.parent.GetComponent<Canvas>() != null)
        {
            Canvas parentCanvas = canvas.transform.parent.GetComponent<Canvas>();
            parentCanvases.AddRange(ParentCanvas(parentCanvas));
            parentCanvases.Add(parentCanvas);
        }
        return parentCanvases;
    }
}
