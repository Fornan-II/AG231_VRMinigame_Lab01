using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulitplierScript : BrickScript
{
    public static bool multiplier = false;
    protected override IEnumerator DestroyAfterLittleBit()
    {
        float t = 0.0f;
        DisableBrick();
        extendedLife = 10f;

        while (t < extendedLife)
        {
            multiplier = true;
            yield return null;
            t += Time.deltaTime;
        }

        score += 2;
        multiplier = false;
        Destroy(gameObject);
    }
}
