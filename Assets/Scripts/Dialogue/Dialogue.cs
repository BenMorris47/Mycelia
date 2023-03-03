using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Dialogue/DialogueSet")]
public class Dialogue : ScriptableObject
{
    [Tooltip("These are the dialogues that will play (These will be in order so be careful)")]
    public DialoguePiece[] dialogueLocations;

    public UnityEvent beginningAction;
    public UnityEvent endAction;

    [System.Serializable]
    public struct DialoguePiece
    {
        public EventReference dialogueReference;
        [TextArea] public string subtitles;
    }
}
