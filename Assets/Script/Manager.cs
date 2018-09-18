using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Manager : MonoBehaviour {
    public Canvas GameMan;
    public Text GOver;
    public GameObject ball;
    public GameObject player;
    public Transform playerSpawn;

    public void Lost()
    {
        Debug.Log("gameover");
        GOver.enabled = true;
       // GameMan.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (GOver.enabled == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GOver.enabled = false;//game over text disabled

                // spawning ball 
                BallScript b = ball.GetComponent<BallScript>();         
                ball.transform.position = b.spawnpt.transform.position;
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                //ball material
                ball.GetComponent<SphereCollider>().material = (PhysicMaterial)Resources.Load("bounce");//to stop bounce

                //spawning player
                player.gameObject.transform.position = playerSpawn.position;
            }
        }
    }

}
