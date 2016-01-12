using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

    float forwardBackwardSpeed;
    float leftRightSpeed;
    CharacterController controller;
    int movementSpeed = 5;
    float leftRightRotation;

	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	
	void Update () {
        leftRightRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0,leftRightRotation,0);
        forwardBackwardSpeed = Input.GetAxis("Vertical");
        leftRightSpeed = Input.GetAxis("Horizontal");
        Vector3 speed = new Vector3(leftRightSpeed, 0, forwardBackwardSpeed) * movementSpeed;
        speed = transform.rotation * speed;
        controller.SimpleMove(speed);
	}
}
