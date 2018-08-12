using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(GunController))]
public class Player : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 10;

	Camera viewCamera;
	PlayerController controller;
	GunController gun;


	void Start () {
		controller = GetComponent<PlayerController>();
		gun = GetComponent<GunController>();
		viewCamera = Camera.main;
	}
	
	void Update() {
		// MOVEMENT
		Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		velocity.Normalize();
		velocity *= moveSpeed;
		controller.move(velocity);

		// LOOKING
		Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayDistance;

		if (groundPlane.Raycast(ray, out rayDistance)) {
			Vector3 hitpoint = ray.GetPoint(rayDistance);
			Debug.DrawLine( ray.origin, hitpoint);
			controller.LookAt(hitpoint);
		}

		// SHOOTING
		if(Input.GetMouseButton(0)) {
			gun.Shoot();
		}
	}
}
