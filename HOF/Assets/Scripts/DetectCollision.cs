using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {
    public bool touching;
    public string touchTag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Player")
        {
            touching = true;
        }
        touchTag = other.transform.tag;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag != "Player")
        {
            touching = false;
        }
    }
}
