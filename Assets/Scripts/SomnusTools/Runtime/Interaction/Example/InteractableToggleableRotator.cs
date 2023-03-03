using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableToggleableRotator : MonoBehaviour, IInteractable
{
	public float MaxRange => 10;
	public bool isOpen;
	public float rotationSpeed = 1;
	private float currentRotationSpeed;
	public Vector3 rotationAmount;
	private Vector3 originalRotation;
	private Vector3 targetRotation;
	public bool isMoving;
	private float currentRotationAmount = 0;
	public string InteractMessage => interactVerb;
	private string interactVerb = "interact";
	public string toOriginVerb = "close";
	public string toTargetVerb = "open";

	private void Start()
	{
		originalRotation = transform.localRotation.eulerAngles;
		targetRotation = originalRotation + rotationAmount;
	}

	public void OnEndHover()
	{
		
	}

	public void OnInteract()
	{
		if (!isOpen)
		{
			RotateToTarget();
			FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/Player (Plyr)/Actions/Plyr_OpenDoor");
		}
		else
		{
			RotateToOrigin();
			FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/Player (Plyr)/Actions/Plyr_CloseDoor");
		}
	}

	private void RotateToOrigin()
	{
		//close
		isOpen = false;
		isMoving = true;
		interactVerb = toTargetVerb;
		currentRotationSpeed = rotationSpeed * -1;
	}

	private void RotateToTarget()
	{
		//open
		isOpen = true;
		isMoving = true;
		interactVerb = toOriginVerb;
		currentRotationSpeed = rotationSpeed;
	}

	public void OnStartHover()
	{

	}

	private void Update()
	{
		if (isMoving)
		{
			currentRotationAmount += currentRotationSpeed * Time.deltaTime;
			transform.localRotation = Quaternion.Euler(Vector3.Lerp(originalRotation, targetRotation, currentRotationAmount));
			if (currentRotationAmount >= 1)
			{
				currentRotationAmount = 1;
				isMoving = false;
			}
			else if (currentRotationAmount <= 0)
			{
				currentRotationAmount = 0;
				isMoving = false;
			}
		}
	}
}
