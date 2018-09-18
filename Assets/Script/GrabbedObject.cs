using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbedObject : MonoBehaviour {

    protected Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    public void SyncWith(Transform holder, Vector3 velocity)
    {
        Debug.Log("Rotation " + holder.rotation);
        transform.rotation = holder.rotation;

        if(_rb)
        {
            Debug.Log("Rigidbody exists, velocity " + velocity);
            Vector3 moveVector = holder.position - transform.position;
            RaycastHit[] allHits = _rb.SweepTestAll(moveVector, moveVector.magnitude, QueryTriggerInteraction.Ignore);
            foreach (RaycastHit rch in allHits)
            {
                if (rch.rigidbody)
                {
                    rch.rigidbody.AddForceAtPosition(velocity, rch.point);
                }
            }
        }
        else
        {
            Debug.Log("No rigidbody on " + name);
        }

        Debug.Log("Position " + holder.position);
        transform.position = holder.position;
    }
}
