using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSInput : MonoBehaviour
{
	FPSInputActions fpsInputActions;
	public FPSInputValue fpsInputValue;
	// public float minLook;
	// public float maxLook;
    // Start is called before the first frame update
    void Awake()
    {
		fpsInputActions = new FPSInputActions();
		fpsInputActions.OnFoot.Enable();
		// fpsInputActions.OnFoot.Move.performed += MovePerformed;
		// fpsInputActions.OnFoot.Look.performed += LookPerformed;
    }


	private void ReadLookInput(InputAction inputAction)
	{
		Vector2 look = inputAction.ReadValue<Vector2>();
		// look.x = Mathf.Clamp(look.x, minLook, maxLook);
		// look.y = Mathf.Clamp(look.y, minLook, maxLook);
		look.x /= Screen.width;
		look.y /= Screen.height;
		fpsInputValue.look = look;
	}

	private void Update() {
		ReadMoveInput(fpsInputActions.OnFoot.Move);
		ReadLookInput(fpsInputActions.OnFoot.Look);
		ReadJumpInput(fpsInputActions.OnFoot.Jump);
		ReadShootInput(fpsInputActions.OnFoot.Shoot);
	}

	private void ReadMoveInput(InputAction inputAction)
	{
		Vector2 direction = inputAction.ReadValue<Vector2>();
		fpsInputValue.move2 = new Vector2(direction.y, direction.x);
		fpsInputValue.move3 = new Vector3(direction.y, 0f, direction.x);
	}

	void ReadShootInput(InputAction inputAction)
	{
		bool vl = inputAction.triggered;
		fpsInputValue.shoot = vl;
	}
	void ReadJumpInput(InputAction inputAction)
	{
		bool vl = inputAction.triggered;
		// if (vl)
			// Debug.Log("ABC");
		fpsInputValue.jump = vl;
	}
}
