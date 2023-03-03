using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour, IInteractable
{

	public string InteractMessage => "";
	public float MaxRange { get { return maxRange; } }
	public const float maxRange = 100f;
	public bool active = true;
	[SerializeField] private bool isToggledOn = false;
	public UnityEvent StartHover;
	public UnityEvent InteractStateOn;
	public UnityEvent InteractStateOff;
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
		ToggleState();
	}

	public void ToggleState() //Toggles between the two interaction states
	{
		if (active && !isToggledOn)
		{
			isToggledOn = true;
			InteractStateOn?.Invoke(); //checks that there is an event attached
			return;
		}
		if (active && isToggledOn)
		{
			isToggledOn = false;
			InteractStateOff?.Invoke(); //checks that there is an event attached
			return;
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

