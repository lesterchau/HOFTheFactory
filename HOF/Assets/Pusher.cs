using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && other.GetComponent<Player>().onLadder && Input.GetKey("w"))
        {
            other.GetComponent<Rigidbody>().velocity = transform.forward;
        }
    }
}
