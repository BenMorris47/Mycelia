using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotographableObject : MonoBehaviour
{
    public HintEntry hintEntry;
    bool hintDiscovered = false;

    public void AddHintToJournal()
    {
        if(!hintDiscovered)
            JournalUIManager.instance.AppendHint(hintEntry);
        hintDiscovered = true;
    }
}
