using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour {

    public Transform Target;
    private GameObject player;
    private bool playerLock = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (playerLock)
        {
            if (Input.GetKey("w"))
            {
                if (player.transform.position.y < Target.position.y)
                {
                    player.transform.position += transform.up * 0.3f;
                }
                else if (player.transform.position.z < Target.position.z)
                {
                    player.transform.position += Target.position - player.transform.position;
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wall Collider")
        {

        }
    }
}
