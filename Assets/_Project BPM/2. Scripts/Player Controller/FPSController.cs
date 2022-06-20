using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using ScriptableObjectArchitecture;
public class FPSController : MonoBehaviour
{
	public FPSInputValue fpsInputValue;
	[Header("Move Speed")]
	public float maxSpeed;
	float speed;
	Vector3 currentVel;
	[Header("Jump and Gravity")]
	public float jumpHeight;
	public float gravity;
	public float terminalVel;
	float verticalVel;
	bool isGrounded;
	[Header("Look Attribute")]
	public Transform playerHead;
	public float lookIntensity;
	CharacterController characterController;
	CinemachineVirtualCamera virtualCamera;

	[Header("Animator")]
	Animator animator;
	int animIDShoot;
	int animIDReload;
	[Header("Abilities")]
	ShootAbility shootAbility;
	public InstantShotAbility instantShoot;
	public GameEvent OnJump;
	[Header("Precision Event")]
	public GameEvent OnCallPrecision;
	public IntVariable precisionIndex;
    // Start is called before the first frame update

	private void Awake() {
		characterController = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator>();
		shootAbility = GetComponent<ShootAbility>();
		SetAnimationID();
	}

	void SetAnimationID()
	{
		animIDShoot = Animator.StringToHash("Shoot");
		animIDReload = Animator.StringToHash("Reload");
	}
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
		JumpAndGravity();
		Move();
		Look();
		Shoot();
		// GroundedCheck();
    }

	void JumpAndGravity()
	{
		isGrounded = GroundedCheck();
		if (isGrounded)
		{
			if (verticalVel < 0f)
				verticalVel = -2f;
			if (fpsInputValue.jump)
			{
				// Debug.Log("ASDASDADS");
				if (OnCallPrecision != null)
					OnCallPrecision.Raise();
				if (precisionIndex <= 2)
				{
					OnJump.Raise();
					verticalVel = Mathf.Sqrt(jumpHeight * 2f * gravity);
				}
			}
		}
		else
		{

		}
		if (verticalVel < terminalVel )
		{
			verticalVel -= gravity*Time.deltaTime;
		}
	}

	bool GroundedCheck()
	{
		return characterController.isGrounded;
		// Debug.Log(characterController.isGrounded);
	}

	void Move()
	{
		Vector3 targetVel = fpsInputValue.move3.x*transform.forward + fpsInputValue.move3.z*transform.right;
		targetVel *= maxSpeed;
		currentVel = targetVel + Vector3.up*verticalVel;
		// characterController.SimpleMove(targetVel + Vector3.up*verticalVel);
		characterController.Move(currentVel*Time.deltaTime);
	}
	void Look()
	{
		Vector3 lookDelta = new Vector3(-fpsInputValue.look.y, fpsInputValue.look.x, 0f);
		lookDelta *= lookIntensity;
		playerHead.eulerAngles += Vector3.right*lookDelta.x;
		transform.eulerAngles += Vector3.up*lookDelta.y;
	}
	void Shoot()
	{
		if (fpsInputValue.shoot)
		{
			// Debug.Log("ABC");
			animator.SetTrigger(animIDShoot);
			// shootAbility.Shoot();
			instantShoot.Shoot();
		}
	}
}
