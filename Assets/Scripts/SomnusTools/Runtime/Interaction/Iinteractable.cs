using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
	string InteractMessage { get; }
	float MaxRange { get; }
	void OnStartHover();
	void OnInteract();
	void OnEndHover();
}

