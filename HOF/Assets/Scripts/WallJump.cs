using UnityEngine;
using System.Collections;

public class WallJump: MonoBehaviour {

    private CharacterController cc;
    private Vector3 lastMove;
    private Vector3 moveVector;
    private float verticalVelocity;
    private float gravity = 25;
    private float jumpForce = 8;
    public float speed = 8;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
    }

    void Update() {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * 5.0f;
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical") * 5.0f;

        //Wall Jump
        if (cc.isGrounded) {
            verticalVelocity = -1;

            if (Input.GetKeyDown(KeyCode.Space)) {
                verticalVelocity = jumpForce;
            }
        }else {
            verticalVelocity -= gravity * Time.deltaTime;
            moveVector = lastMove;
        }
        moveVector.y = 0;
        moveVector.Normalize();
        moveVector *= speed;
        moveVector.y = verticalVelocity;

        cc.Move(moveVector * Time.deltaTime);
        lastMove = moveVector;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(!cc.isGrounded && hit.normal.y < 0.1f) {
            if (Input.GetKey(KeyCode.Space)) {
                verticalVelocity = jumpForce;
                moveVector = hit.normal * speed;
            }           
        }        
    }
}