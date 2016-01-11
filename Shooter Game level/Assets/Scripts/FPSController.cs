using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

    float forwardBackwardSpeed;
    float leftRightSpeed;
    CharacterController controller;
    int movementSpeed = 5;
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	
	void Update () {
        forwardBackwardSpeed = Input.GetAxis("Vertical");
        leftRightSpeed = Input.GetAxis("Horizontal");
        Vector3 speed = new Vector3(leftRightSpeed, 0, forwardBackwardSpeed) * movementSpeed;

        controller.SimpleMove(speed);
	}
}
