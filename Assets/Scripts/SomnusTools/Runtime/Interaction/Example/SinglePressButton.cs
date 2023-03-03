using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SinglePressButton : MonoBehaviour, IInteractable
{
	public string InteractMessage => interactMessage;
	public string interactMessage;
	public float MaxRange { get { return maxRange; } }
	public const float maxRange = 100f;
	public bool active = true;
	public bool destroyOnInteract = false;
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
			active = false;
			if (destroyOnInteract)
			{
				Destroy(this);
			}
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
