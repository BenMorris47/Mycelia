using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	public float fallLimit = -10;
	public bool useFallLimit = true;
	public float speed = 12f;
	public Vector3 gravity = new Vector3(0f,-9.8f,0f);
	public float jumpHeight = 3;
	Vector3 velocity;
	Vector2 movement = Vector2.zero;
	public Transform pCamera;

	//Ground Check
	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	bool isGrounded;
	bool playerJumpedThisFrame;
	public Vector3 lastGroundedPos;
	public Quaternion lastGroundedRotation;

	public float footStepSoundDelay = 0.5f;
	private float footStepSoundTimer = 0;

	private void OnEnable()
	{
		ControlsManager.instance.controls.PlayerMovement.Jump.performed += context => playerJumpedThisFrame = context.action.triggered;
		ControlsManager.instance.controls.PlayerMovement.Movement.performed += context => movement = context.ReadValue<Vector2>();
	}
	private void OnDisable()
	{
		ControlsManager.instance.controls.PlayerMovement.Jump.performed -= context => playerJumpedThisFrame = context.action.triggered;
		ControlsManager.instance.controls.PlayerMovement.Movement.performed -= context => movement = context.ReadValue<Vector2>();
	}



    private void Update()
	{
		bool prevGrounded = isGrounded;
		isGrounded = controller.isGrounded;
		if (isGrounded) // used for respawning
		{
			lastGroundedPos = transform.position;
			lastGroundedRotation = transform.rotation;
		}
		if (!prevGrounded && isGrounded) //player landed
		{
			FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/Player (Plyr)/Movement/Plyr_Land");
		}
		if (footStepSoundTimer <= 0 && movement.magnitude > 0 && isGrounded)// play movement sounds
		{
			FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/Player (Plyr)/Movement/Plyr_Footstep");
			footStepSoundTimer = footStepSoundDelay;
		}
		else
		{
			footStepSoundTimer -= 1 * Time.deltaTime;
		}
		if (useFallLimit && transform.position.y < fallLimit) // respawns player if thay fall too far
        {
			if (lastGroundedPos != null)
			{
				transform.position = lastGroundedPos;
				transform.rotation = lastGroundedRotation;

			}
			else
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
			return;
		}
		Move();
	}

	public void Move()
	{
		//Rotating Player
		Vector3 targetEuler = pCamera.transform.rotation.eulerAngles;
		Vector3 playerEuler = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(playerEuler.x,targetEuler.y,playerEuler.z);

		if (isGrounded && velocity.y < 0)
		{
			//keeps player stuck to slopes
			velocity.y = -2;
		}

		float x = movement.x;
		float y = movement.y;
		
		
		//moves the player
		Vector3 move = transform.right * x + transform.forward * y;
		controller.Move(move * speed * Time.deltaTime);

		//jumping
		if (playerJumpedThisFrame && isGrounded)
		{
			playerJumpedThisFrame = false;
			velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity.y);
			FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/Player (Plyr)/Movement/Plyr_Jump");
		}
		else
		{
			playerJumpedThisFrame = false;
		}
		//moves the player down according to gravity
		velocity += (gravity * Time.deltaTime) + (gravity * Time.deltaTime);
		controller.Move(velocity * Time.deltaTime);

	}

	public void StopMoving()
	{
		movement = Vector2.zero;
	}

    private void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawCube(new Vector3(transform.position.x, fallLimit, transform.position.z), new Vector3(10, 1, 10));
    }
}
