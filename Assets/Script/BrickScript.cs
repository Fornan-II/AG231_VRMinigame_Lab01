﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    public static int bricksRemaining = 0;
    protected static int totalBrickCount = 0;
    public GameObject destroyParticlePrefab;
    public float particleLifeTime;
    public static int score;

    AudioSource glass;
    protected virtual void Start()
    {
        glass = GetComponent<AudioSource>();
        totalBrickCount++;
        bricksRemaining++;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if (destroyParticlePrefab)
            {
                glass.Play(0);
                GameObject particle = Instantiate(destroyParticlePrefab, collision.transform.position, collision.transform.rotation);
                Destroy(particle, particleLifeTime);
            }
            Destroy(gameObject);
            bricksRemaining--;
        }
    }

    private void Update()
    {
        score = totalBrickCount - bricksRemaining;
    }

    public static void ResetBrickCount()
    {
        bricksRemaining = 0;
        totalBrickCount = 0;
    }
}
