using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public ObjectiveScriptable newObjective;

    /// <summary>
    /// This is what changes the objective and will be called in the events
    /// </summary>
    public void ChangeObjective()
    {
        ObjectiveManager.instance.UpdateObjectives(newObjective);
    }
}

public enum ObjectiveChanger
{
    NEWOBJ,
    COMPLETEOBJ,
}