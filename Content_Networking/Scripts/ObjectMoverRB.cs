using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class ObjectMoverRB :  MonoBehaviour
{
	private float moveHorizontal;			//Variables to construct the movement and rotation values
	private float moveVertical;

	private Rigidbody localRigidBody;		//Cache the reference to the rigidbody

	public float translationSpeed = 5.0f;	//The ammount of unity the object will move at

	public float rotationSpeed = 45.0f;		//In euler angles, the speed of the roation


	void Start()
	{
		//Get the reference to the object's rigidbody since we will be using it a lot
		localRigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		//Get the horizontal and vertical input. We do that differently depending on the platform
		#if UNITY_IOS || UNITY_ANDROID || UNITY_WSA_10_0
			moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
			moveVertical = CrossPlatformInputManager.GetAxis("Vertical"); 
		#else
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		#endif

		//Calculate and apply the new translation
		Vector3 deltaTranslation = transform.position + transform.forward * translationSpeed * moveVertical * Time.deltaTime;
		localRigidBody.MovePosition (deltaTranslation);

		//Calculate and apply the new rotation
		Quaternion deltaRotation = Quaternion.Euler (rotationSpeed * new Vector3 (0, moveHorizontal, 0) * Time.deltaTime);
		localRigidBody.MoveRotation (localRigidBody.rotation * deltaRotation);
	}
}
