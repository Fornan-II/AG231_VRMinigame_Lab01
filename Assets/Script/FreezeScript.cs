﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeScript : BrickScript {
    protected override IEnumerator DestroyAfterLittleBit(Collision ball)
    {
        float t = 0.0f;
        DisableBrick();

        extendedLife = 3f;

        if (MulitplierScript.multiplier == true)
        { score += 2; }
        score++;

        Rigidbody ballRB = ball.gameObject.GetComponent<Rigidbody>();
        Vector3 vel = ballRB.velocity;
        Vector3 avel = ballRB.angularVelocity;

        while (t < extendedLife)
        {
            if (ballRB)
            {
                ballRB.isKinematic = true;
            }
            yield return null;
            t += Time.deltaTime;
        }
        
        ballRB.isKinematic = false;
        ballRB.velocity = vel;
        ballRB.angularVelocity = avel;

        Destroy(gameObject);
    }

}
