using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//modified version of Gravity walker script from http://wiki.unity3d.com/index.php/GravityFPSWalker found from the post https://answers.unity.com/questions/1512978/how-can-i-get-a-responsive-rigidbody-fps-controlle.html
[RequireComponent(typeof(Rigidbody))]
public class RBPlayerMovement : MonoBehaviour
{
	public Transform LookTransform;
	public Vector3 Gravity = Vector3.down * 9.81f;
	public float RotationRate = 0.1f;
	public float Velocity = 8;
	public float GroundControl = 1.0f;
	public float AirControl = 0.2f;
	public float JumpVelocity = 5;
	public float GroundHeight = 1.1f;
	private bool jump;
	private Rigidbody rb;
	bool playerJumpedThisFrame;
	Vector2 movement = Vector2.zero;
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
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		rb.useGravity = false;
	}

	void Update()
	{
		jump = jump || playerJumpedThisFrame;
	}

	void FixedUpdate()
	{
		// Cast a ray towards the ground to see if the Walker is grounded
		bool grounded = Physics.Raycast(transform.position, Gravity.normalized, GroundHeight);

		// Add velocity change for movement on the local horizontal plane
		Vector3 forward = Vector3.Cross(transform.up, -LookTransform.right).normalized;
		Vector3 right = Vector3.Cross(transform.up, LookTransform.forward).normalized;
		Vector3 targetVelocity = (forward * movement.y + right * movement.x) * Velocity;
		Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
		Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity) - localVelocity;

		// The velocity change is clamped to the control velocity
		// The vertical component is either removed or set to result in the absolute jump velocity
		velocityChange = Vector3.ClampMagnitude(velocityChange, grounded ? GroundControl : AirControl);
		velocityChange.y = jump && grounded ? -localVelocity.y + JumpVelocity : 0;
		velocityChange = transform.TransformDirection(velocityChange);
		rb.AddForce(velocityChange, ForceMode.VelocityChange);

		// Add gravity
		rb.AddForce(Gravity * rb.mass);

		jump = false;
		playerJumpedThisFrame = false;
	}
}
