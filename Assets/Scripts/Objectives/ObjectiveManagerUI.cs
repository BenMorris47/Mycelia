using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManagerUI : MonoBehaviour
{
    public float decayTime;

    public GameObject objectivePlayModePanel;
    public TextMeshProUGUI objectivePlayModeText;

    public TextMeshProUGUI objectivePauseModeText;

    Coroutine coroutine;

    public void DisplayObjectiveUpdate(ObjectiveScriptable newObjective, ObjectiveScriptable newlyCompletedObjective)
    {
            coroutine = StartCoroutine(ObjectiveDecay(decayTime, newObjective, newlyCompletedObjective));

        objectivePauseModeText.text = "Objective: \n" + newObjective.name;

    }

    private IEnumerator ObjectiveDecay(float decayTime, ObjectiveScriptable newObjective, ObjectiveScriptable newlyCompletedObjective)
    {
        objectivePlayModePanel.SetActive(true);

        if (newlyCompletedObjective != null)
        {
            objectivePlayModeText.text = "Completed Objective: \n" + newlyCompletedObjective.name;
            yield return new WaitForSeconds(decayTime);
        }
        objectivePlayModeText.text = "New Objective: \n" + newObjective.name;
        yield return new WaitForSeconds(decayTime);

        objectivePlayModePanel.SetActive(false);
    }
}
