using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulitplierScript : BrickScript
{
    public static bool multiplier = false;
    protected override IEnumerator DestroyAfterLittleBit(Collision ball)
    {
        float t = 0.0f;
        DisableBrick();
        extendedLife = 3f;
        score += 2;

        while (t < extendedLife)
        {
            multiplier = true;
            yield return null;
            t += Time.deltaTime;
        }

       
        multiplier = false;
        Destroy(gameObject);
    }
}
