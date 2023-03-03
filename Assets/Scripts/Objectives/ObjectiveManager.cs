using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ObjectiveManager : MonoBehaviour
{
    public List<ObjectiveScriptable> allObjectives;
    public ObjectiveScriptable currentObjective;
    public static ObjectiveManager instance;
    ObjectiveManagerUI uiManager;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        uiManager = GameObject.FindObjectOfType<ObjectiveManagerUI>();
    }

    public void UpdateObjectives(ObjectiveScriptable newObjective)
    {
        newObjective.ProgressObjective();
        if (currentObjective != null)
        {
            currentObjective.ProgressObjective();
        }

        uiManager.DisplayObjectiveUpdate(newObjective, currentObjective);
        currentObjective = newObjective;
    }


}
