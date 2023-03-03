using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyEventTrigger : MonoBehaviour
{
    public UnityEvent onDestroyEvent;

	private void OnDestroy()
	{
		onDestroyEvent?.Invoke();
	}
}
