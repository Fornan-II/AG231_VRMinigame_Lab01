using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour {
    LineRenderer laserLine;

    void Start () {
        laserLine = GetComponent<LineRenderer>();
        laserLine.enabled = false;
    }	
	
	void Update () {
        if (Input.GetButton("Fire2"))
        {
            Debug.Log("BUTTON PUSHED");
            RaycastHit hit;
            laserLine.enabled = true;

            Vector3 rayOrigin = gameObject.transform.position;
            laserLine.SetPosition(0, gameObject.transform.position);

            if (Physics.Raycast(rayOrigin, gameObject.transform.forward, out hit, 10))
            {
                Debug.Log("Pointing at " + hit.transform.name);
                laserLine.SetPosition(1, hit.point);
                Button b = hit.transform.GetComponent<Button>();
                if(b)
                {
                    b.onClick.Invoke();
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (gameObject.transform.forward * 10));
            }
        }
        else
        {
            laserLine.enabled = false;
        }
    }
}
