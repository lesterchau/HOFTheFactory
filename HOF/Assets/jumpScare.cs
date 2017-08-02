using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScare : MonoBehaviour {

    private AudioSource jumpscare;
    private bool play = false;

	// Use this for initialization
	void Start () {
        jumpscare = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (play && WallTrigger.canBreak)
        {
            jumpscare.Play();
            play = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            play = true;
        }
    }
}
