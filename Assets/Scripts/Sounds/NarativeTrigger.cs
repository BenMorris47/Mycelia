using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NarativeTrigger : MonoBehaviour
{
	public UnityEvent triggeredEnterEvent;
	public bool destroyOnExit = true;
	private void OnTriggerEnter(Collider other)
	{
		triggeredEnterEvent?.Invoke();
	}

	private void OnTriggerExit(Collider other)
	{
		if (destroyOnExit)
		{
			Destroy(gameObject);
		}
	}
}
