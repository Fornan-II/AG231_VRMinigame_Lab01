using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    public static int bricksRemaining = 0;
    protected static int totalBrickCount = 0;
    public GameObject destroyParticlePrefab;
    public float particleLifeTime;
    public static int score
    {
        get
        {
            return totalBrickCount - bricksRemaining;
        }
    }

    protected Collider _col;
    protected MeshRenderer _mr;

    public float extendedLife = 0.0f;

    protected virtual void Start()
    {
        totalBrickCount++;
        bricksRemaining++;
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
            StartCoroutine(DestroyAfterLittleBit());
        }
    }

    public static void ResetBrickCount()
    {
        bricksRemaining = 0;
        totalBrickCount = 0;
    }

    protected virtual IEnumerator DestroyAfterLittleBit()
    {
        float t = 0.0f;
        DisableBrick();

        while(t < extendedLife)
        {
            yield return null;
            t += Time.deltaTime;
        }

        Destroy(gameObject);
        bricksRemaining--;
    }

    protected virtual void DisableBrick()
    {
        if(_col) { _col.enabled = false; }
        if(_mr) { _mr.enabled = false; }
    }
}
