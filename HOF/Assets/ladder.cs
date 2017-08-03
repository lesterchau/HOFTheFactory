using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour {

    public Transform Target;
    private GameObject player;
    public bool playerLock = false;
    private bool finishClimb = false;
    public float moveSpeed = 4;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (playerLock && player.transform.position.y > Target.position.y)
        {
            finishClimb = true;
        }

        if (finishClimb)
        {
            if (Vector3.Distance(Target.position, player.transform.position) > 0.1f)
            {
                float step = moveSpeed * Time.deltaTime;
                player.transform.position = Vector3.MoveTowards(player.transform.position, Target.position, step);
            }
            else
            {
                finishClimb = false;
                playerLock = false;
                player.GetComponent<RigidBodyPlayerController>().climbing = false;
                player.GetComponent<RigidBodyPlayerController>().rb.useGravity = true;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wall Collider")
        {
            player.GetComponent<RigidBodyPlayerController>().climbing = true;
            playerLock = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Wall Collider")
        {
            player.GetComponent<RigidBodyPlayerController>().climbing = false;
            playerLock = false;
        }
    }
}
