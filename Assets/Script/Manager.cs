using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Manager : MonoBehaviour {
    public Canvas GameMan;
    public Text GOver;

    public void Lost()
    {
        Debug.Log("gameover");
        GOver.enabled = true;
       // GameMan.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (GOver.enabled == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GOver.enabled = false;
            }
        }
    }

}
