using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject spawnpt;
    public GameObject SceneManager;
    public float minimumForwardVelocity = 0.0f;
    public float maximumVelocity = 5.0f;
    protected Rigidbody _rb;
    public static bool startGame;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        startGame = false;
    }

    private void FixedUpdate()
    {
        if(_rb.velocity.sqrMagnitude > maximumVelocity * maximumVelocity)
        {
            _rb.velocity = _rb.velocity.normalized * maximumVelocity;
        }

        //starts game
        if(_rb.isKinematic == false)
        {
            startGame = true;
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


    private void OnCollisionStay(Collision collision)
    {
        if (_rb && minimumForwardVelocity != 0.0f)
        {
            if (Mathf.Abs(_rb.velocity.z) < minimumForwardVelocity)
            {
                float zVel = minimumForwardVelocity;
                if (_rb.velocity.z <= 0.0f)
                {
                    zVel *= -1.0f;
                }
                _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, zVel);
            }
        }
    }
}
