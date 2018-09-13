using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject spawnpt;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            gameObject.transform.position = spawnpt.transform.position;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
