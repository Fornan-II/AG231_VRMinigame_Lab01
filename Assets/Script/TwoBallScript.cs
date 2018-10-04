using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBallScript : BrickScript {

    protected override IEnumerator DestroyAfterLittleBit(Collision ball)
    {
        float t = 0.0f;
        DisableBrick();

        extendedLife = 20f;

        if (MulitplierScript.multiplier == true)
        { score += 2; }
        score++;

        Rigidbody ballRB = ball.gameObject.GetComponent<Rigidbody>();
        Vector3 vel = ballRB.velocity;
        Vector3 avel = ballRB.angularVelocity;

        GameObject newBall = Instantiate(ball.gameObject, ball.transform.position, ball.transform.rotation);
        Rigidbody newBallRB = newBall.GetComponent<Rigidbody>();
        newBallRB.velocity = vel * -1;
        newBallRB.velocity = avel;

        while (t < extendedLife)
        {
            yield return null;
            t += Time.deltaTime;
        }

        Destroy(newBall);
        Destroy(gameObject);
    }
}
