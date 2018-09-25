﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Grabby : MonoBehaviour {

    public OVRInput.Controller thisController;
    public float grabRadius = 0.5f;
	public bool centerGrabbedObject = false;
    public LayerMask grabMask;
    public string GrabInput;

    protected GameObject grabbedObject;
    protected GrabbedObject grabbedObjectScript;
    protected bool isGrabbing = false;
    public static bool startGame;

    

    protected virtual void GrabObject()
    {
        isGrabbing = true;

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);
        if(hits.Length > 0)
        {
            int closestHitIndex = 0;
            for(int i = 0; i < hits.Length; i++)
            {
                if(hits[i].distance > hits[closestHitIndex].distance)
                {
                    closestHitIndex = i;
                }
            }

            grabbedObject = hits[closestHitIndex].transform.gameObject;
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            if(rb)
            {
                rb.isKinematic = true;
            }

            grabbedObjectScript = grabbedObject.GetComponent<GrabbedObject>();
            if(grabbedObjectScript)
            {
                grabbedObjectScript.myHolder = this;
            }
            grabbedObject.transform.parent = transform;
            if (centerGrabbedObject)
            {
                grabbedObject.transform.localPosition = Vector3.zero;
            }
        }
    }

    protected virtual void DropObject()
    {
        isGrabbing = false;

        if (!grabbedObject) { return; }

        grabbedObject.transform.parent = null;
        Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.isKinematic = false;
            rb.velocity = OVRInput.GetLocalControllerVelocity(thisController);
            rb.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(thisController);            
        }

        if (grabbedObjectScript)
        {
            grabbedObjectScript.myHolder = null;
            grabbedObjectScript = null;
        }

        grabbedObject = null;
    }

    
    protected virtual void FixedUpdate () {
        //hacky start game
        startGame = BallScript.startGame;

        if(!XRDevice.isPresent) { return; }

        float triggerValue = Input.GetAxis(GrabInput);
        
        if (!isGrabbing && triggerValue == 1)
        {
            GrabObject();
        }else if(isGrabbing && triggerValue < 1)
        {
            DropObject();
        }

        if(grabbedObjectScript)
        {
            //grabbedObjectScript.SyncWith(transform, OVRInput.GetLocalControllerVelocity(thisController));
            grabbedObjectScript.myVelocity = OVRInput.GetLocalControllerVelocity(thisController);
        }
	}

    public void Vibrate()
    {
        if(!XRDevice.isPresent) { return; }

        //OVRHaptics.
    }
}
