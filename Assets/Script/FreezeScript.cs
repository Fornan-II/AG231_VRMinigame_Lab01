using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeScript : BrickScript {
    protected override IEnumerator DestroyAfterLittleBit()
    {
        float t = 0.0f;
        DisableBrick();

        extendedLife = 3f;

        if (MulitplierScript.multiplier == true)
        { score += 2; }
        score++;

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Rigidbody ballRB = null;
        Vector3 vel = ballRB.velocity;
        Vector3 avel = ballRB.angularVelocity;

        while (t < extendedLife)
        {
            ballRB = ball.GetComponent<Rigidbody>();
            if (ballRB)
            {
                ballRB.isKinematic = false;
            }
            yield return null;
            t += Time.deltaTime;
        }
        
        ballRB.isKinematic = true;
        ballRB.velocity = vel;
        ballRB.angularVelocity = avel;

        Destroy(gameObject);
    }

}
