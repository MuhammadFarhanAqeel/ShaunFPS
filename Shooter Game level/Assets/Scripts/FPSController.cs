using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

    float forwardBackwardSpeed;
    float leftRightSpeed;
    CharacterController controller;
    int movementSpeed = 5;
    float horizontalRotation;
    float verticalRotation;
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	
	void Update () {

        verticalRotation -= Input.GetAxis("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation, -50, 50);
        this.GetComponentInChildren<Camera>().transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        horizontalRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0,horizontalRotation,0);
        forwardBackwardSpeed = Input.GetAxis("Vertical");
        leftRightSpeed = Input.GetAxis("Horizontal");
        Vector3 speed = new Vector3(leftRightSpeed, 0, forwardBackwardSpeed) * movementSpeed;
        speed = transform.rotation * speed;
        controller.SimpleMove(speed);
	}
}
