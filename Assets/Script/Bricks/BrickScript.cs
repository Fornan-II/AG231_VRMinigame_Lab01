using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {
    
    public GameObject destroyParticlePrefab;
    public float particleLifeTime;
    public static int score = 0;
    /*public static int score
    {
        get
        {
            return totalBrickCount - bricksRemaining;
        }
    }*/

    protected Collider _col;
    protected MeshRenderer _mr;

    public float extendedLife = 0.0f;

    protected virtual void Start()
    {
        _col = gameObject.GetComponent<Collider>();
        _mr = gameObject.GetComponent<MeshRenderer>();
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
            StartCoroutine(DestroyAfterLittleBit(collision));
        }
    }

    public static void ResetBrickCount()
    {
        score = 0;
    }

    protected virtual IEnumerator DestroyAfterLittleBit(Collision ball)
    {
        float t = 0.0f;
        DisableBrick();

        if (MulitplierScript.multiplier == true)
        { score +=2; }

        score++;

        while (t < extendedLife)
        {
            yield return null;
            t += Time.deltaTime;
        }

        
        Destroy(gameObject);
    }

    protected virtual void DisableBrick()
    {
        if(_col) { _col.enabled = false; }
        if(_mr) { _mr.enabled = false; }
    }
}
