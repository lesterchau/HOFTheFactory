using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour {

    public GameObject ladderCollider;
    private DetectCollision checker;

    public float climbSpeed;
    private Rigidbody rb;
    private RigidBodyPlayerController cc;

	// Use this for initialization
	void Start () {
        checker = ladderCollider.GetComponent<DetectCollision>();
        cc = GetComponent<RigidBodyPlayerController>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (checker.touching && checker.touchTag == "Ladder")
        {
            rb.useGravity = false;
            if (Input.GetKey("w"))
            {
                transform.Translate(new Vector3(0, 1, 0) * climbSpeed);
            }
            else if (Input.GetKey("s"))
            {
                transform.Translate(new Vector3(0, -1, 0) * climbSpeed);
            }

        }
        else
        {
            rb.useGravity = true;
        }
	}
}
