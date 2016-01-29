using UnityEngine;
using System.Collections;

public class missileSpeed : MonoBehaviour {

    float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
	}
}
