using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
	public float MaxRange { get { return maxRange; } }
	public const float maxRange = 100f;
	public UnityEvent OnEnter;
	public UnityEvent OnStay;
	public UnityEvent OnExit;

	private void OnTriggerEnter(Collider other)
	{
		if (OnEnter != null) //checks if there are events subscribed and if there are it invokes them
		{
			OnEnter.Invoke();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (OnStay != null) //checks if there are events subscribed and if there are it invokes them
		{
			OnStay.Invoke();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (OnExit != null) //checks if there are events subscribed and if there are it invokes them
		{
			OnExit.Invoke();
		}
	}
}
