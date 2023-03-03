using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objective/New Objective")]
public class ObjectiveScriptable : ScriptableObject
{
    public string objectiveName;
    [TextArea]public string objectiveDescription;
    public ObjectiveProgress curProgress { get; private set; }

    public void ProgressObjective()
    {
        if (curProgress != ObjectiveProgress.COMPLETE)
        {
            curProgress++;
        }
    }
}

public enum ObjectiveProgress
{
    UNDISCOVERED,
    INCOMPLETE,
    COMPLETE,
}

