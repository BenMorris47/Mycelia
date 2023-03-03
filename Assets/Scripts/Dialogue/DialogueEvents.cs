using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEvents : MonoBehaviour
{
    public Dialogue dialogue;
    public bool destoryGameObjectOnEnd = false;
    public UnityEvent startEvent;
    public UnityEvent endEvent;

    public void DialogueStarter()
    {
        DialogueManager.instance.StartDialogue(this);
    }
}
