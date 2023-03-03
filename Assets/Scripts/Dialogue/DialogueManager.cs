using FMOD;
using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
    public static DialogueManager instance;
    Coroutine dialogueCoroutine;
    EventInstance currentEvent;
    DialogueEvents lastEvent;
    [SerializeField] DialogueHistory lastHistory;

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
    }
    public void StartDialogue(DialogueEvents events)
    {
        currentEvent.getPlaybackState(out PLAYBACK_STATE state);
        if (state == PLAYBACK_STATE.PLAYING)
        {
            for (int i = 0; i < events.dialogue.dialogueLocations.Length; i++)
            {
                lastHistory.history.Add(events.dialogue.dialogueLocations[i]);
            }

            currentEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            try
            {
                StopCoroutine(dialogueCoroutine);
            }
            catch (System.Exception){ }

            lastEvent.endEvent?.Invoke();
        }
        dialogueCoroutine = StartCoroutine(ProgressDialogue(events));
    }

    private IEnumerator ProgressDialogue(DialogueEvents events)
    {
        lastEvent = events;
        events.startEvent?.Invoke();


        if (events.dialogue != null)
        {
            for (int i = 0; i < events.dialogue.dialogueLocations.Length; i++)
            {
                PLAYBACK_STATE state = PLAYBACK_STATE.STARTING;

                currentEvent = PlayOneShot(events.dialogue.dialogueLocations[i].dialogueReference.Guid, events.gameObject.transform);
                subtitleText.text = events.dialogue.dialogueLocations[i].subtitles;

                while (state != PLAYBACK_STATE.STOPPED)
                {
                    currentEvent.getPlaybackState(out state);
                    yield return new WaitForEndOfFrame();
                }
                subtitleText.text = "";
            }
        }
        events.endEvent?.Invoke();

        if (events.gameObject != null && events.destoryGameObjectOnEnd)
        {
            Destroy(events.gameObject);
        }
    }

    public EventInstance PlayOneShot(GUID path, Transform position)
    {
        EventInstance instance = RuntimeManager.CreateInstance(path);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(new Vector3()));
        instance.start();
        RuntimeManager.AttachInstanceToGameObject(instance, position);
        instance.release();
        return instance;
    }

    private void Update()
    {
        
    }
}
