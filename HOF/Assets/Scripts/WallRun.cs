using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallRun : MonoBehaviour {

    private bool isWallR = false;
    private RigidBodyPlayerController cc;
    private Rigidbody rb;
    public float runTime = 1.5f;
    private float wallRunTimer;
    private RaycastHit wallHit;
    public bool wallRun = false;
    public bool reset = true;
    public float wallRunVel = 5;

    void Start() {
        cc = GetComponent<RigidBodyPlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update() {

        if (cc.grounded)
        {
            reset = true;
        }

        if (!wallRun && reset) {
            checkForWall();
        }
        else
        {
            confirmWallRun();
        }
    }
    
    private void checkForWall()
    {
        
        RaycastHit hit = new RaycastHit();
        if (!cc.grounded && (rb.velocity.x > 0 || rb.velocity.z > 0) && cc.sprinting 
            && Time.time > wallRunTimer && reset && rb.velocity.y <= 0)
        {
            if (Physics.Raycast(transform.position, -transform.right, out hit, 1))
            {
                if (hit.transform.tag == "Wall")
                {
                    isWallR = false;
                    cc.falling = false;
                    wallRunTimer = Time.time + runTime;
                    wallRun = true;
                    reset = false;
                    wallHit = hit;
                    rb.useGravity = false;
                    speedBoost();
                }
            }
            else if (Physics.Raycast(transform.position, transform.right, out hit, 1))
            {
                if (hit.transform.tag == "Wall")
                {
                    isWallR = true;
                    cc.falling = false;
                    wallRunTimer = Time.time + runTime;
                    wallRun = true;
                    reset = false;
                    wallHit = hit;
                    rb.useGravity = false;
                    speedBoost();
                }
            }

        }
    }

    private void speedBoost()
    {
        rb.velocity = Vector3.zero;
        float direction;
        print(wallHit.normal);
        if(wallHit.normal.x == 0.0f) 
        {
            if (transform.forward.x > 0)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            rb.velocity = new Vector3(wallRunVel * direction, 0, 0);
            print(rb.velocity);
        }
        else
        {
            if (transform.forward.z > 0)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            rb.velocity = new Vector3(0, 0, wallRunVel * direction);
            print(rb.velocity);
        }

    }

    private void confirmWallRun()
    {
        //rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        cc.falling = false;
        float direction;
        if (isWallR)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        if (!Physics.Raycast(transform.position, transform.right * direction, 1) || Input.GetKeyDown("space") || Time.time > wallRunTimer || cc.grounded)
        {
            cancelWallRun();
        }
    }

    private void cancelWallRun()
    {
        cc.falling = true;
        wallRunTimer = 0;
        wallRun = false;
        rb.useGravity = true;
    }
}