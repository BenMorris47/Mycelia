using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodPlayOnInteract : MonoBehaviour, IInteractable
{
	public string InteractMessage => "Pick up";
	public FMODUnity.EventReference audioClip;
	public bool destroyOnInteract = true;

	public float MaxRange => 5;

	public void OnEndHover()
	{
		
	}

	public void OnInteract()
	{
		FMODUnity.RuntimeManager.PlayOneShot(audioClip);
		if (destroyOnInteract)
		{
			Destroy(gameObject);
		}
	}

	public void OnStartHover()
	{
		
	}
}
