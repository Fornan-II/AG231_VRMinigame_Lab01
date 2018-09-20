using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject spawnpt;
    public GameObject SceneManager;
    public float minimumForwardVelocity = 0.0f;
    protected Rigidbody _rb;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }
    /*private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            gameObject.transform.position = spawnpt.transform.position;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }*/

    private void FixedUpdate()
    {
        if(_rb && minimumForwardVelocity != 0.0f)
        {
            if (Mathf.Abs(_rb.velocity.z) < minimumForwardVelocity)
            {
                float zVel = minimumForwardVelocity;
                if(_rb.velocity.z <= 0.0f)
                {
                    zVel *= -1.0f;
                }
                _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, zVel);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "backwall")
        {
            Debug.Log(collision.gameObject.name);
            //gameObject.GetComponent<BallScript>().enabled = false;
            
            Manager sm = SceneManager.GetComponent<Manager>();
            sm.Lost();

        }
    }

}
