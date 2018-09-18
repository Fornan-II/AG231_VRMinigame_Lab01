using System.Collections;
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
    public GrabbedObject grabbedObjectScript;
    protected bool isGrabbing = false;

	protected virtual void GrabObject()
    {
        Debug.Log("Try to grab.");
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
            if(rb) { rb.isKinematic = true; }

            GrabbedObject grabbedObjectScript = grabbedObject.GetComponent<GrabbedObject>();
            Debug.Log(grabbedObjectScript.name + " is the thingy");
            if(!grabbedObjectScript)
            {
                grabbedObject.transform.parent = transform;
                if (centerGrabbedObject)
                {
                    grabbedObject.transform.localPosition = Vector3.zero;
                }
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
            Debug.Log(name + " releases");
            rb.isKinematic = false;
            rb.velocity = OVRInput.GetLocalControllerVelocity(thisController);
            rb.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(thisController);
            //This line above, MAKE SURE IT WORKS. @ 28:58 in the video, the guy used a different approach.
        }

        if (grabbedObjectScript)
        {
            grabbedObjectScript = null;
        }

        grabbedObject = null;
    }

    // Update is called once per frame
    protected virtual void Update () {
        if(!XRDevice.isPresent) { return; }

        float triggerValue = Input.GetAxis(GrabInput);

        //Debug.Log(name + " velocity " + OVRInput.GetLocalControllerAngularVelocity(thisController));
        if (!isGrabbing && triggerValue == 1)
        {
            GrabObject();
        }else if(isGrabbing && triggerValue < 1)
        {
            DropObject();
        }
        

        if(grabbedObjectScript)
        {
            Debug.Log("Has grabbedObjectScript");
            grabbedObjectScript.SyncWith(transform, OVRInput.GetLocalControllerVelocity(thisController));
        }
	}
}
