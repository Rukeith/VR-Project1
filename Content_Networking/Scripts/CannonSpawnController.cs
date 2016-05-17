using UnityEngine;
using System.Collections;

public class CannonSpawnController : MonoBehaviour
{
	[SerializeField] float power = 800f;		//How hard to shoot the cannonballs
	[SerializeField] GameObject cannonBall;

	private Transform playerCanon;				//Where should the cannonballs shoot from


	void Start ()
	{
		//Get the location of the cannon
		playerCanon = transform.FindChild("CannonSpawnpoint");
	}


	void Update ()
	{
		//If we click the mouse or hit the spacebar...
		if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
		{

			//...we instantiate a cannonball from Resources
			GameObject instance = Instantiate (cannonBall) as GameObject; 
			//Let's name it
			instance.name = "Cannonball";
			//Let's position it at the cannon
			instance.transform.position = playerCanon.position;
			//Let's send it forward
			instance.GetComponent<Rigidbody> ().AddForce (playerCanon.forward * power);
		}
	}
}
