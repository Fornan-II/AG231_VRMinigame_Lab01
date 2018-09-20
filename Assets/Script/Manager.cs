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
    public Image PauseMenu;
    public GameObject ball;
    public GameObject player;
    public GameObject paddle;
    public Transform playerSpawn;
    public Transform paddleSpawn;
    float timeLeft = 10.0f;
    bool lose;

    public void Start()
    {
        lose = false;
        TimeText.text = "Time: " + timeLeft;
    }
    public void Lost()
    {
        GOver.enabled = true;
        ball.GetComponent<SphereCollider>().material = null;        
    }



    private void Update()
    {
        if (Grabby.startGame == true)
        {
            if (lose == false)
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
            else
            {
                TimeText.text = "Time: 0"; //bc it would end on a negative number
            }
        }

        if(Input.GetButtonDown("Fire3"))
        {
            if (PauseMenu.gameObject.activeSelf == false)
            {
                PauseMenu.gameObject.SetActive(true);
            }
            else// if (PauseMenu.gameObject.activeSelf == true)
            {
                PauseMenu.gameObject.SetActive(false);
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