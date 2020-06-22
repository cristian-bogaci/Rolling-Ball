using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//public float PlayerSpeed;
	public float horizontalSpeed;
	public float horizontalRotatingSpeed;
	public float runSpeed;
	private Vector3 horizontalMovement;
	private Vector3 horizontalRotation;
	public int grounded;
	public float maxSpeed;
 
	void Start(){

	}


	void OnCollisionEnter(Collision hit){
			if(hit.collider.tag == "Ground"){
				grounded = 1;
		}
	}

	void Update(){
		horizontalRotation.z = horizontalMovement.x;
	}
		
	void FixedUpdate () {

		if(grounded == 1){
			horizontalMovement.x = Input.acceleration.x; //for Android
			//horizontalMovement.x = Input.GetAxis("Horizontal"); // for Windows
			if(GetComponent<PlayerDeath>().dead == false){
				if(GetComponent<Rigidbody>().velocity.z <= maxSpeed){
					GetComponent<Rigidbody>().AddForce(Vector3.forward * runSpeed * 10 * Time.fixedDeltaTime);
				}
				transform.Translate(-horizontalMovement * horizontalSpeed * Time.fixedDeltaTime, Space.World);
				transform.Rotate(horizontalRotation * horizontalRotatingSpeed * 10 * Time.fixedDeltaTime, Space.World);
			}

		}
	}
}
