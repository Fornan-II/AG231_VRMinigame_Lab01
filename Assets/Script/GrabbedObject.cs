using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbedObject : MonoBehaviour {

    protected Rigidbody _rb;
    public Vector3 myVelocity;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    //public void SyncWith(Transform holder, Vector3 velocity)
    //{
    //    if(_rb)
    //    {
    //        Vector3 moveVector = holder.position - transform.position;
    //        RaycastHit[] allHits = _rb.SweepTestAll(moveVector, moveVector.magnitude, QueryTriggerInteraction.Ignore);
            
    //        foreach (RaycastHit rch in allHits)
    //        {
    //            if (rch.rigidbody)
    //            {
    //                Debug.DrawRay(transform.position, moveVector, Color.red, 1.0f);
    //                UnityEditor.EditorApplication.isPaused = true;
    //                rch.rigidbody.AddForceAtPosition(velocity, rch.point);
    //                Debug.Log("Hit " + rch.transform.gameObject.name + " with velocity " + velocity);
    //            }
    //        }
    //    }

    //    myVelocity = velocity;
    //    transform.rotation = holder.rotation;
    //    transform.position = holder.position;
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " collided");
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb)
        {
            Vector3 newVelocity = Vector3.Project(rb.velocity, myVelocity) + myVelocity;
            Debug.Log(newVelocity);
            _rb.velocity = newVelocity;
        }
    }
}
