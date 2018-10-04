using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeBrick : BrickScript {

    public float SlowTimeScale = 0.5f;

    protected override IEnumerator DestroyAfterLittleBit()
    {
        float t = 0.0f;
        DisableBrick();
        extendedLife = 3.0f;

        if (MulitplierScript.multiplier == true)
        { score += 2; }

        score++;

        while (t < extendedLife)
        {
            Manager.runTimeScale = SlowTimeScale;
            yield return null;
            t += Time.deltaTime;
        }

        Manager.runTimeScale = 1.0f;
        Destroy(gameObject);
    }

}
