using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravBrick : BrickScript {

    public GameObject gravParticle;
    public float noGravDuration = 3.0f;

    protected override IEnumerator DestroyAfterLittleBit(Collision ball)
    {
        float t = 0.0f;
        DisableBrick();

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        List<Rigidbody> ballsRB = new List<Rigidbody>();
        foreach(GameObject b in balls)
        {
            if(gravParticle)
            {
                GameObject gp = Instantiate(gravParticle, ball.transform);
                Destroy(gp, noGravDuration);
            }
            Rigidbody ballRB = b.GetComponent<Rigidbody>();
            if(ballRB)
            {
                ballRB.useGravity = false;
                ballsRB.Add(ballRB);
            }
        }

        if (MulitplierScript.multiplier == true)
        { score += 2; }
        score++;

        while (t < noGravDuration)
        {
            yield return null;
            t += Time.deltaTime;
        }

        foreach (Rigidbody ballRB in ballsRB)
        {
            if(ballRB)
            {
                ballRB.useGravity = true;
            }
        }
        
        Destroy(gameObject);
    }
}
