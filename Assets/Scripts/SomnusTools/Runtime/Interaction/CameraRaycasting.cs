using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.InputAction;

namespace SomnusTools
{
	public class CameraRaycasting : MonoBehaviour
	{
		[SerializeField] private float range = 5f;

		[SerializeField] private IInteractable currentTarget;
		public Camera mainCamera;
		public Vector2 mousePos;
		public LayerMask mask;
		public Controls controls;
		public GameObject interactMessageObject;
		private TextMeshProUGUI interactMessageTextMesh;
		public string interactMessageText = "Press E to ";

		private void Awake()
		{
			if (mainCamera == null)
			{
				mainCamera = Camera.main;
			}
			controls = new Controls();
			controls.InteractionSystem.MousePos.performed += context => UpdateMousePos(context.action.ReadValue<Vector2>());
			controls.InteractionSystem.Interact.performed += context => Interact();
			interactMessageTextMesh = interactMessageObject.GetComponent<TextMeshProUGUI>();
		}
		void OnEnable() => controls.Enable();
		void OnDisable() => controls.Disable();
		public void Interact()
		{
			if (currentTarget != null)
			{
				currentTarget.OnInteract();
				RaycastForInteractable();
			}
		}

		public void UpdateMousePos(Vector2 mousePos)
		{
			this.mousePos = mousePos;
			RaycastForInteractable();
		}

		private void RaycastForInteractable()
		{
			RaycastHit hit;

			Ray ray = mainCamera.ScreenPointToRay(mousePos);
			Debug.DrawRay(ray.direction, ray.direction * range);
			if (Physics.Raycast(ray, out hit, range,mask))
			{
				IInteractable interactable = hit.collider.GetComponent<IInteractable>();

				if (interactable != null)
				{
					interactMessageTextMesh.text = interactMessageText + interactable.InteractMessage;
					if (hit.distance <= interactable.MaxRange)
					{
						if (interactable == currentTarget)
						{
							return;
						}
						else if (currentTarget != null)
						{
							currentTarget.OnEndHover();
							currentTarget = interactable;
							currentTarget.OnStartHover();
							return;
						}
						else
						{
							currentTarget = interactable;
							currentTarget.OnStartHover();
							interactMessageObject?.SetActive(true);
							return;
						}
					}
					else
					{
						if (currentTarget != null)
						{
							currentTarget.OnEndHover();
							interactMessageObject?.SetActive(false);
							currentTarget = null;
							return;
						}
					}
				}
				else
				{
					if (currentTarget != null)
					{
						currentTarget.OnEndHover();
						interactMessageObject?.SetActive(false);
						currentTarget = null;
						return;
					}
				}
			}
			else
			{
				if (currentTarget != null)
				{
					currentTarget.OnEndHover();
					interactMessageObject?.SetActive(false);
					currentTarget = null;
					return;
				}
			}
		}

	}
}


