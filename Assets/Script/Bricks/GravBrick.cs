﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravBrick : BrickScript {

    public GameObject gravParticle;
    public float noGravDuration = 3.0f;

    protected override IEnumerator DestroyAfterLittleBit()
    {
        float t = 0.0f;
        DisableBrick();

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Rigidbody ballRB = null;
        if(ball)
        {
            GameObject gp = Instantiate(gravParticle, ball.transform);
            Destroy(gp, noGravDuration);
            ballRB = ball.GetComponent<Rigidbody>();
            if(ballRB)
            {
                ballRB.useGravity = false;
            }
        }

        while (t < noGravDuration)
        {
            yield return null;
            t += Time.deltaTime;
        }

        if(ballRB)
        {
            ballRB.useGravity = true;
        }

        if (MulitplierScript.multiplier == true)
        { score = +2; }
        score++;
        Destroy(gameObject);
    }
}
