using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class InteractableToggleableMover : MonoBehaviour, IInteractable
{
	public string InteractMessage => interactMessage;
	public string interactMessage = "";

	public string interactMessageAtTarget = "";
	public string interactMessageAtOrigin = "";
	public FMODUnity.EventReference moveSoundToOrigin;
	public FMODUnity.EventReference moveSoundToTarget;
	public float MaxRange => 10;
	public bool isMoved;
	public float movementSpeed = 1;
	private float currentMovementSpeed;
	public Vector3 offsetAmount;
	private Vector3 originalPosition;
	private Vector3 targetPosition;
	public bool isMoving;
	private float currentMovementAmount = 0;

	private void Start()
	{
		originalPosition = transform.localPosition;
		targetPosition = originalPosition + offsetAmount;
		interactMessage = interactMessageAtOrigin;
	}

	public void OnStartHover()
	{
		
	}

	public void OnEndHover()
	{

	}

	public void OnInteract()
	{
		if (!isMoved)
		{
			MoveToTarget();
			FMODUnity.RuntimeManager.PlayOneShot(moveSoundToTarget);
			interactMessage = interactMessageAtTarget;
		}
		else
		{
			MoveToOrigin();
			FMODUnity.RuntimeManager.PlayOneShot(moveSoundToOrigin);
			interactMessage = interactMessageAtOrigin;
		}
	}

	private void MoveToOrigin()
	{
		isMoved = false;
		isMoving = true;
		currentMovementSpeed = movementSpeed * -1;
	}

	private void MoveToTarget()
	{
		isMoved = true;
		isMoving = true;
		currentMovementSpeed = movementSpeed;
	}

	

	private void Update()
	{
		if (isMoving)
		{
			currentMovementAmount += currentMovementSpeed * Time.deltaTime;
			transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, currentMovementAmount);
			if (currentMovementAmount >= 1)
			{
				currentMovementAmount = 1;
				isMoving = false;
			}
			else if (currentMovementAmount <= 0)
			{
				currentMovementAmount = 0;
				isMoving = false;
			}
		}
	}
}

