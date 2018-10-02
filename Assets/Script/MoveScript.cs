using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public Rigidbody rb;
    public Transform head;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 newVelocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        Vector3 newVelocity = head.forward * Input.GetAxis("Vertical") + head.right * Input.GetAxis("Horizontal");
        newVelocity.y = 0.0f;
        newVelocity *= moveSpeed * Time.deltaTime;
        rb.velocity = newVelocity;
	}
}
