using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacheteHallwayTrigger : MonoBehaviour {

    public GameObject machete;
    private macheteHallway target;
    private bool on = true;

	// Use this for initialization
	void Start () {
        target = machete.GetComponent<macheteHallway>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (on && other.transform.tag == "Player")
        {
            target.activate();
            on = false;
        }
    }


}
