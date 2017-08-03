using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Silde : MonoBehaviour {

    private bool isSlided;
    private CapsuleCollider capsuleCollider;
    private float slideTimer = 0;
    public float slideTime = 1.0f;
    private RigidBodyPlayerController cc;
    public float crouchHeight = 0.5f;
    private float normalHeight;
    public Transform FPSCamera;
    public Vector3 cameraPosition;
    public float crouchCameraHeight = 0.7f;

    void Start() {
        capsuleCollider = GetComponent<CapsuleCollider>();
        cc = GetComponent<RigidBodyPlayerController>();
        normalHeight = capsuleCollider.height;
        cameraPosition = FPSCamera.localPosition;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && cc.grounded){
            slideTimer =Time.time + slideTime;
            capsuleCollider.height = crouchHeight;
            cc.sliding = true;
        }
        if (Input.GetKeyUp(KeyCode.Q) || Time.time > slideTimer)
        {
            capsuleCollider.height = normalHeight;
            slideTimer = 0f;
            cc.sliding = false;
        }

        if (cc.sliding && FPSCamera.localPosition.y > crouchCameraHeight)
        {
            FPSCamera.transform.position += -transform.up * 0.3f;
        }
        else if (!cc.sliding && FPSCamera.localPosition.y < cameraPosition.y)
        {
            FPSCamera.transform.position += transform.up * 0.3f;
        }
    }
}