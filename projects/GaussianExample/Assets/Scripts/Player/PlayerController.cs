using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	#region Editor Variables

	[SerializeField]
	[Tooltip("How fast the player is.")]
	private float m_Speed;

	public Transform cameraTransform;
	#endregion

	#region Cached Components
	private Rigidbody cc_Rb;
	#endregion
	
    #region Private Variables
    //move direction of the player
	private Vector3 movementDirection;
	private float forwardInput;
	private float rightInput;
    #endregion

    #region Initialization
    private void Awake()
    {
		cc_Rb = GetComponent<Rigidbody>();
		cc_Rb.freezeRotation = true;
    }

	private void Start() 
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
    #endregion

    #region Main Update
    private void Update()
	{
        forwardInput = Input.GetAxis("Vertical");
        rightInput = Input.GetAxis("Horizontal");

		Vector3 threshold = new Vector3(cc_Rb.velocity.x, 0f, cc_Rb.velocity.z);
		if (threshold.magnitude > m_Speed)
		{
			Vector3 limitedVelocity = threshold.normalized * m_Speed;
			cc_Rb.velocity = new Vector3(limitedVelocity.x, cc_Rb.velocity.y, limitedVelocity.z);
		}

	}

	private void FixedUpdate() 
	{
		movementDirection = cameraTransform.forward * forwardInput + cameraTransform.right * rightInput;
		if (Input.GetKeyDown("space"))	{
			Debug.Log("jump");
			movementDirection += new Vector3(0, 20f, 0);
		}
		cc_Rb.AddForce(movementDirection * m_Speed * 2f, ForceMode.Force);

		/*if (forwardInput == 0 && rightInput == 0)
		{
			cc_Rb.velocity = Vector3.zero;
			cc_Rb.angularVelocity = Vector3.zero;

		}	else //if (forwardInput >= 0)
        {
			movementDirection = cameraTransform.forward * forwardInput + cameraTransform.right * rightInput;
			cc_Rb.AddForce(movementDirection * m_Speed * 10f, ForceMode.Force);
		}*/
	}
	#endregion
}
