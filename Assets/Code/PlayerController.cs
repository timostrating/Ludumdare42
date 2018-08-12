using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    private Vector3 velocity;

	private Rigidbody myRigidbody;
	private Transform myTransform;


	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
		myTransform = transform;
	}

    private void FixedUpdate() {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
	
	public void move(Vector3 velocity) {
		this.velocity = velocity;
	}

	public void LookAt(Vector3 interestingSpot) {
		Vector3 lookPosition = new Vector3(interestingSpot.x, myTransform.position.y, interestingSpot.z);
		myTransform.LookAt(lookPosition);
	}

}
