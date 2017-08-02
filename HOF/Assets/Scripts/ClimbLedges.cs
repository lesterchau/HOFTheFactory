using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLedges : MonoBehaviour {

    public bool climbing = false;

    private Vector3 ledgeVector;
    private Vector3 ledgeColliderStart;

    public GameObject wallCollider;
    public GameObject ledgeCollider;
    private Rigidbody rb;
    private float ledgeColliderDisToGround;

    private RigidBodyPlayerController cc;

    // Use this for initialization
    void Start () {
        ledgeColliderDisToGround = ledgeCollider.GetComponent<CapsuleCollider>().height / 2;
        cc = GetComponent<RigidBodyPlayerController>();
        rb = GetComponent<Rigidbody>();
        ledgeColliderStart = ledgeCollider.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        if (wallCollider.GetComponent<DetectCollision>().touching && !climbing && !cc.grounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
            {
                if (hit.transform.tag == "Stone Ledge" || hit.transform.tag == "Hollow Metal Ledge" || hit.transform.tag == "Solid Metal Ledge" || hit.transform.tag == "Ledge")
                {
                    detectLedge();
                }
            }
        }

        if (climbing)
        {
            climbLedge();
        }
    }

    private void detectLedge()
    {
        bool ledgeFound = false;
        while (ledgeCollider.transform.position.y > transform.position.y && !ledgeFound )
        {
            ledgeCollider.transform.position += Vector3.down * 0.05f;
            RaycastHit hit;
            if (Physics.Raycast(ledgeCollider.transform.position, -ledgeCollider.transform.up, out hit, ledgeColliderDisToGround + 0.1f))
            {
                if (hit.transform.tag == "Stone Ledge" || hit.transform.tag == "Hollow Metal Ledge" || hit.transform.tag == "Solid Metal Ledge" || hit.transform.tag == "Ledge")
                {
                    ledgeFound = true;
                }
            }
        }
        if (ledgeFound)
        {
            climbing = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            ledgeVector = ledgeCollider.transform.position;
        }
        ledgeCollider.transform.localPosition = ledgeColliderStart;
    }

    private void climbLedge()
    {
        if (transform.position.y < ledgeVector.y)
        {
            transform.position += Vector3.up * 0.4f;
        }
        else if (Vector3.Distance(transform.position, ledgeVector) > 0.1f)
        {
            transform.position += (ledgeVector - transform.position).normalized * 0.4f;
        }
        else
        {
            climbing = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
