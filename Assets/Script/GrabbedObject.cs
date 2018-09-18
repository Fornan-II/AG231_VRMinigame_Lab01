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
        transform.rotation = holder.rotation;

        if(_rb)
        {
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

        transform.position = holder.position;
    }
}
