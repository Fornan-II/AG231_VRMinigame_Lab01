using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

	void Start () {
        MusicScript[] ms = FindObjectsOfType<MusicScript>();

        if (ms.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
	
}
