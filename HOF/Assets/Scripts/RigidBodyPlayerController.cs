using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyPlayerController : MonoBehaviour {

    public float walkSpeed = 5.0f;
    public float runSpeed = 12.0f;
    private float speed = 5.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 5.0f;
    public Rigidbody rb;
    public bool sprinting;
    private float disToGround;
    public bool falling = false;
    private Player player;
    public bool grounded = true;
    private float sprintStopTimer;
    public bool sliding = false;
    public bool climbing = false;


    void Awake()
    {
        rb.freezeRotation = true;
        disToGround = (GetComponent<CapsuleCollider>().height / 2) * transform.lossyScale.y;
        player = GetComponent<Player>();
    }

    void FixedUpdate()
    {
        grounded = isGrounded();
        if (Time.time > sprintStopTimer && grounded)
        {
            sprinting = false;
        }
        if (Input.GetKey(KeyCode.LeftShift) && player.stamina > 0)
        {
            sprinting = true;
            maxVelocityChange = runSpeed;
            speed = runSpeed;
        }
        if (climbing && !grounded)
        {
            rb.useGravity = false;
        }
        if (grounded && !player.dead && !sliding)
        {
            float speedMod = 1;
            falling = false;
            // Calculate how fast we should be moving
            if (Input.GetAxis("Vertical") < 0)
            {
                speedMod = 0.3f;
            }
            else if (climbing)
            {
                speedMod = 0;
            }
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal") * 0.7f , 0, Input.GetAxis("Vertical") * speedMod);
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            if (!climbing)
            {
                velocityChange.y = 0;
            }
            else if (Input.GetAxis("Vertical")  == 1)
            {
                velocityChange.y = 0.5f;
            }
            rb.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (grounded && Input.GetKeyDown("space") && player.stamina > 0)
            {
                rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
                falling = true;
            }
        }


        //if the don't move then the player isn't sprinting
        if (rb.velocity.x == 0 || rb.velocity.z == 0)
        {
            sprinting = false;
        }

        // We apply gravity manually for more tuning control
        if (falling)
        {
            rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
        }
        maxVelocityChange = walkSpeed;
        speed = walkSpeed;

        if (Input.GetKeyDown(KeyCode.LeftShift) && player.stamina > 0)
        {
            sprintStopTimer = Time.time + 0.7f;
        }
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, -transform.up, disToGround + 0.1f);
    }
}
