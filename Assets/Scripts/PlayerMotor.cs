using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
	[RequireComponent(typeof(CharacterController))]
	public class PlayerMotor : MonoBehaviour
	{
		private InputAction MoveAction => moveActionReference.action;
		private InputAction JumpAction => jumpActionReference.action;

		[SerializeField]
		private InputActionReference moveActionReference;
		[SerializeField]
		private InputActionReference jumpActionReference;

		private float speed;
		[SerializeField]
		private float jumpForce = 2f;

		private CharacterController controller;
		private Vector3 movement;

		private void Awake()
		{
			controller = GetComponent<CharacterController>();
			
			MoveAction.Enable();
			MoveAction.performed += OnMovePerformed;
			MoveAction.canceled += OnMoveCancelled;
			
			JumpAction.Enable();
			JumpAction.performed += OnJumpPerformed;

			speed = PlayerPrefs.GetFloat("speed", 1f);
		}
		
		private void FixedUpdate()
		{
			if(!controller.isGrounded)
			{
				movement.y += Physics.gravity.y * Time.fixedDeltaTime;
			}

			Vector3 movementVector = movement * (speed * Time.fixedDeltaTime);

			controller.Move(transform.forward * movementVector.z + 
			                transform.up * movementVector.y);

			transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y + 2, transform.localRotation.z);
		}

		private void OnMovePerformed(InputAction.CallbackContext _context)
		{
			Vector2 input = _context.ReadValue<Vector2>();
			movement.x = input.x;
			movement.z = input.y;
		}

		private void OnMoveCancelled(InputAction.CallbackContext _context)
		{
			movement.x = 0;
			movement.z = 0;
		}
		
		private void OnJumpPerformed(InputAction.CallbackContext _context)
		{
			movement.y = jumpForce;
		}
	}
}