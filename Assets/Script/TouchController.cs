using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TouchController : MonoBehaviour {

    public OVRInput.Controller thisController;

	// Update is called once per frame
	void Update () {
        if(XRDevice.isPresent)
        {
            transform.localPosition = OVRInput.GetLocalControllerPosition(thisController);
            transform.localRotation = OVRInput.GetLocalControllerRotation(thisController);
        }
    }
}
