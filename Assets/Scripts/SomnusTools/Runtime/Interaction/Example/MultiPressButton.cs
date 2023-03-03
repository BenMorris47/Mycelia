using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiPressButton : MonoBehaviour, IInteractable
{
	public string InteractMessage => "";
	public float MaxRange { get { return maxRange; } }
	public const float maxRange = 100f;
	public bool active = true;
	public UnityEvent StartHover;
	public UnityEvent Interact;
	public UnityEvent EndHover;

	public void OnStartHover()
	{
		if (StartHover != null && active) //checks if there are events subscribed and if there are it invokes them
		{
			StartHover.Invoke();
		}
	}

	public void OnInteract()
	{
		if (Interact != null && active) //checks if there are events subscribed and if there are it invokes them
		{
			Interact.Invoke();
		}

	}

	public void OnEndHover()
	{
		if (EndHover != null && active) //checks if there are events subscribed and if there are it invokes them
		{
			EndHover.Invoke();
		}
	}


}

