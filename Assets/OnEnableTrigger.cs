using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableTrigger : MonoBehaviour
{
    public UnityEvent onEnableEvents;
    private void Start()
    {
        onEnableEvents?.Invoke();
    }
}
