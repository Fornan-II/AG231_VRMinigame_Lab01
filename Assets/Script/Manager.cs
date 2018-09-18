using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    public Canvas GameMan;
    public Text GOver;
    public Text ScoreText;
    public GameObject ball;
    public GameObject player;
    public GameObject paddle;
    public Transform playerSpawn;
    public Transform paddleSpawn;
    

    public void Lost()
    {
        Debug.Log("gameover");
        GOver.enabled = true;
        ball.GetComponent<SphereCollider>().material = null;
       // GameMan.gameObject.SetActive(true);
    }



    private void Update()
    {
        ScoreText.text = "Score: " + BrickScript.score;

        if (GOver.enabled == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("GameScene");
                /*GOver.enabled = false;//game over text disabled

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

                //spawning paddle
                paddle.gameObject.transform.position = paddleSpawn.position;
                paddle.gameObject.transform.rotation = paddleSpawn.rotation;

                //score reset
                ScoreText.text = "Score: " + BrickScript.score;*/
            }
        }
    }

}
