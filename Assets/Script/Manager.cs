using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * Dana LeMay, Maxen McCoy
 * Lab01
 * AG231
 * Fall2018
 */

public class Manager : MonoBehaviour {
    public Canvas GameMan;
    public Text GOver;
    public Text ScoreText;
    public Text TimeText;
    public GameObject ball;
    public GameObject player;
    public GameObject paddle;
    public Transform playerSpawn;
    public Transform paddleSpawn;
    float timeLeft = 20.0f;
    bool lose;

    public void Lost()
    {
        Debug.Log("gameover");
        GOver.enabled = true;
        ball.GetComponent<SphereCollider>().material = null;
        lose = false;
        // GameMan.gameObject.SetActive(true);
    }



    private void Update()
    {
        if(lose == false)
        {
            Debug.Log("lose is false");
            timeLeft -= Time.deltaTime;
            TimeText.text = "Time: " + timeLeft;
            if (timeLeft < 0)
            {
                Debug.Log("lose");
                Lost();
                lose = true;
            }
        }
        
        ScoreText.text = "Score: " + BrickScript.score;

        if (GOver.enabled == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("GameScene");
                
            }
        }
    }

}


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