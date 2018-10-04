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
    public Image StartMenu;
    public Image PauseMenu;
    public Image InstructionsMenu;
    public GameObject ball;
    public GameObject player;
    public GameObject paddle;
    public Transform playerSpawn;
    public Transform paddleSpawn;
    public Text pause;
    public Text pausedGOver;
    public float timeLeft = 10.0f;
    bool lose;
    bool paused;
    protected bool doRestart;

    public static float runTimeScale = 1.0f;    

    public static bool PAUSE_GAME = false;

    public void Start()
    {
        lose = false;
        paused = false;
        runTimeScale = 1.0f;

        TimeText.text = "Time: " + timeLeft;

        StartMenu.gameObject.SetActive(true);
        InstructionsMenu.gameObject.SetActive(false);
    }
    public void Lost()
    {
        GOver.enabled = true;
        lose = true;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        //Collider col = ball.GetComponent<Collider>();
        rb.isKinematic = true;
        //col.enabled = false;

        PauseMenu.gameObject.SetActive(true);
        pausedGOver.gameObject.SetActive(true);
        pause.gameObject.SetActive(false);
    }



    private void Update()
    {   //timer
        if (Grabby.startGame == true) //ballscript, grabby, manager
        {
            if (paused == false)
            {
                if (lose == false)
                {
                    //Debug.Log("lose is false");
                    timeLeft -= Time.deltaTime * Time.timeScale;
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
        }

        //start menu
        if(Grabby.startGame == true)
        {
            StartMenu.gameObject.SetActive(false);            
        }

        //Pausing
        if ((lose == false && Grabby.startGame == true) || PAUSE_GAME)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (PauseMenu.gameObject.activeSelf == false)
                {
                    PauseMenu.gameObject.SetActive(true);

                    pausedGOver.gameObject.SetActive(false);
                    pause.gameObject.SetActive(true);

                    Time.timeScale = 0.0f;
                    PAUSE_GAME = true;
                }
                else// if (PauseMenu.gameObject.activeSelf == true)
                {
                    PauseMenu.gameObject.SetActive(false);
                    PAUSE_GAME = false;

                    Time.timeScale = runTimeScale;
                }
            }
        }

        if (PauseMenu.gameObject.activeSelf == true)
        {
            paused = true;
        }
        else
        {
            paused = false;
        }

        if(!lose && !PAUSE_GAME)
        {
            Time.timeScale = runTimeScale;
        }

        //updating score
        if (lose == false)
        {
            ScoreText.text = "Score: " + BrickScript.score;
        }

        //updating highscore
        if (BrickScript.score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.GetInt("Highscore", BrickScript.score);
        }

        //restart script
        if (lose == true)
        {
            if (ScoreManager.HighScore < BrickScript.score)
            {
                ScoreManager.HighScore = BrickScript.score;
                ScoreManager.SaveScore();
            }
            if (doRestart)
            {   
                Time.timeScale = runTimeScale;
                BrickScript.ResetBrickCount();
                SceneManager.LoadScene("NewGameScene");                
            }
        }
    }
    public void GoBackB()
    {
        StartMenu.gameObject.SetActive(true);
        InstructionsMenu.gameObject.SetActive(false);
    }
    public void Instructions()
    {
        StartMenu.gameObject.SetActive(false);
        InstructionsMenu.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Restarto");
        lose = true;
        doRestart = true;
    }

    public void EndGame()
    {
        Debug.Log("Quito");
        Application.Quit();
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