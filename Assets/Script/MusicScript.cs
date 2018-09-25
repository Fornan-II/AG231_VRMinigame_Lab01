using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

	void Start () {
        if(FindObjectOfType<MusicScript>())
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
	
}
