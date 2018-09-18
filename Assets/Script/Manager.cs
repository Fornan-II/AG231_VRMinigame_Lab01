using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public Canvas GameOver;

    public void Lost()
    {
        GameOver.enabled = true;
    }

    private void Update()
    {
        if (GameOver.enabled == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameOver.enabled = false;

            }
        }
    }

}
