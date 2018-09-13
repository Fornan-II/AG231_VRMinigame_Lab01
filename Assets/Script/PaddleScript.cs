using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    public int speed = 5;
    public int maxV = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            GameObject ball = collision.gameObject;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb.velocity.magnitude >= maxV)
            {

            }
            else
            {
                rb.velocity *= speed;
            }
        }
    }
}
