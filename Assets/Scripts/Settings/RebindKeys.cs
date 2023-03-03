using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq;
using UnityEngine.UI;

public class RebindKeys : MonoBehaviour
{

    //NOT USED
    [Tooltip("The action you wish to change")]
    [SerializeField] private InputActionReference action;
    [Tooltip("ONLY USE THIS ON PASSTHROUGH ACTIONS SUCH AS 2DVECTOR")]
    [SerializeField] private int additionalIncrease = 0;
    [Tooltip("The textbox showing what the current binding is")]
    [SerializeField] private TextMeshProUGUI displayBinding = null;
    [Tooltip("The button which starts the rebinding")]
    [SerializeField] private Button startRebindObject = null;
    [Tooltip("The text showing 'Waiting For Input'")]
    [SerializeField] private TextMeshProUGUI waitingForInput = null;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private void Start()
    {
        RebindComplete();
    }

    private void OnValidate()
    {
        if (action.action.type == InputActionType.PassThrough)
        {

        }
    }
    public void StartRebinding()
    {
        startRebindObject.gameObject.SetActive(false);
        waitingForInput.gameObject.SetActive(true);
        rebindingOperation = action.action.PerformInteractiveRebinding(additionalIncrease).WithControlsExcluding("Mouse").OnMatchWaitForAnother(0.1f).OnComplete(operation => RebindComplete()).WithCancelingThrough("<Keyboard>/escape").OnCancel(operation => RebindComplete()).OnGeneratePath(action => CheckBindings(action)).Start();
    }
    [ContextMenu("TestStuff")]
    private string CheckBindings(InputControl action)
    {
        var actionMaps = ControlsManager.instance.controls.asset.actionMaps;

        string newInput = "";

        for (int i = action.path.Length - 1; i > 0; i--)
        {
            if (action.path[i] != '/')
            {
                newInput += action.path[i];
            }
            else
            {
                newInput.Reverse();
                break;
            }
        }
        foreach (var controls in actionMaps)
        {
            foreach (var item in controls.bindings)
            {
                string otherInput = null;

                for (int i = item.effectivePath.Length - 1; i > 0; i--)
                {
                    if (item.effectivePath[i] != '/')
                    {
                        otherInput += item.effectivePath[i];
                    }
                    else
                    {
                        otherInput.Reverse();
                        break;
                    }
                }
                if (otherInput == newInput)
                {
                    Debug.Log($"Returned: {this.action.action.bindings[0].effectivePath}");
                    return this.action.action.bindings[additionalIncrease].effectivePath;
                }
            }
        }

        return action.path;
    }
    private void RebindComplete()
    {

        var bindingIndex = action.action.GetBindingIndexForControl(action.action.controls[additionalIncrease]);

        if (bindingIndex < 0)
        {
            throw new System.Exception("bindingIndex has returned " + bindingIndex);
        }
        else
        {
            displayBinding.text = InputControlPath.ToHumanReadableString(action.action.bindings[bindingIndex + additionalIncrease].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
            rebindingOperation?.Dispose();
        }

        startRebindObject.gameObject.SetActive(true);
        waitingForInput.gameObject.SetActive(false);
    }

}