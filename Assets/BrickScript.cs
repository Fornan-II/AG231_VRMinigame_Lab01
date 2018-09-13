using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    public static int ballsRemaining = 0;
    protected static int totalBallCount = 0;
    public GameObject destroyParticlePrefab;
    public float particleLifeTime;

    protected virtual void Start()
    {
        totalBallCount++;
        ballsRemaining++;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if(destroyParticlePrefab)
            {
                GameObject particle = Instantiate(destroyParticlePrefab, collision.transform.position, collision.transform.rotation);
                Destroy(particle, particleLifeTime);
            }
            Destroy(gameObject);
            ballsRemaining--;
        }
    }
}
