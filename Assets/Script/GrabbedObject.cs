using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbedObject : MonoBehaviour {

    [HideInInspector]
    public Grabby myHolder = null;
    protected Rigidbody _rb;
    public Vector3 myVelocity;
    public float hitMultiplier = 1.5f;
    public AudioSource woosh;
    public AudioSource hit;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(myVelocity.magnitude > 3)
        {
            ulong delay = (ulong)10;
            woosh.Play(delay);
        }
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

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name + " collided");
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb)
        {
            hit.Play(0);

            Vector3 newVelocity = Vector3.Project(rb.velocity, myVelocity) + myVelocity;
            if(newVelocity.z <= 0.0f) { Debug.Log("return"); return; }
            newVelocity *= hitMultiplier;
            //Vector3 newVelocity = myVelocity.normalized * rb.velocity.magnitude;// + myVelocity;
            //Debug.Log("Stuff is happening: " + newVelocity);
            Debug.DrawRay(rb.position, newVelocity, Color.white, 100.0f);
            //UnityEditor.EditorApplication.isPaused = true;
            rb.velocity = newVelocity;

            if (myHolder) { myHolder.Vibrate(); };
        }
    }
}
