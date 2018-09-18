using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject spawnpt;
    public GameObject SceneManager;
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
    private void OnCollisionExit(Collision collision)
    {
       
        PaddleScript paddle = collision.gameObject.GetComponent<PaddleScript>();
        if (paddle)
        {
            

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity += paddle.handVelocity;
            /*if (rb.velocity.magnitude >= maxV)
            {

            }
            else
            {
                rb.velocity *= speed;
            }*/
            Debug.Log(collision.gameObject.name);
            Debug.Log(rb.velocity.magnitude);
        }
        if(collision.gameObject.name == "backwall")
        {
            Debug.Log(collision.gameObject.name);
            //gameObject.GetComponent<BallScript>().enabled = false;
            gameObject.GetComponent<SphereCollider>().material = null; //to stop bounce
            SceneManager.GetComponent<Manager>().Lost();      

        }


    }

}
