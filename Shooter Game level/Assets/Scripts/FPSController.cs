using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

    float forwardBackwardSpeed;
    float leftRightSpeed;
    CharacterController controller;
    int movementSpeed = 5;
    float horizontalRotation;
    float verticalRotation;
    float verticalVelocity;
    float jumpSpeed = 4.0f;
    void Start () {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
	}
	
	void Update () {

        verticalRotation -= Input.GetAxis("Mouse Y") * movementSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -50, 50);
        this.GetComponentInChildren<Camera>().transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        horizontalRotation = Input.GetAxis("Mouse X") * movementSpeed;
        transform.Rotate(0,horizontalRotation,0);
        forwardBackwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        leftRightSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        verticalVelocity += Physics.gravity.y * Time.deltaTime ;
        if (Input.GetButtonDown("Jump") && controller.isGrounded) 
        {
            verticalVelocity = jumpSpeed;
        }

        Vector3 speed = new Vector3(leftRightSpeed, verticalVelocity, forwardBackwardSpeed) ;
        speed = transform.rotation * speed;
        controller.Move(speed * Time.deltaTime);

      
	}
}
