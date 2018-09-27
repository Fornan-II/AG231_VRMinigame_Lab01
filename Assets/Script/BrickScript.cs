using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    public static int bricksRemaining = 0;
    protected static int totalBrickCount = 0;
    public GameObject destroyParticlePrefab;
    public float particleLifeTime;
    public static int score;

    protected virtual void Start()
    {
        totalBrickCount++;
        bricksRemaining++;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if (destroyParticlePrefab)
            {
                GameObject particle = Instantiate(destroyParticlePrefab, collision.transform.position, collision.transform.rotation);
                /*AudioSource glassAudio = particle.GetComponent<AudioSource>();
                if(glassAudio)
                {
                    glassAudio.Play(0);
                }*/
                Destroy(particle, particleLifeTime);
            }
            Destroy(gameObject);
            bricksRemaining--;
        }
    }

    private void Update()
    {
        score = totalBrickCount - bricksRemaining;
    }

    public static void ResetBrickCount()
    {
        bricksRemaining = 0;
        totalBrickCount = 0;
    }
}
