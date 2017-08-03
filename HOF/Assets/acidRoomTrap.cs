using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidRoomTrap : MonoBehaviour {

    public GameObject acid;
    public acidTrapTrigger trigger;
    public float raiseHeight = 2;
    public float raiseSpeed = 5;
    private float targetPosition;

	// Use this for initialization
	void Start () {
        targetPosition = transform.position.y + raiseHeight;
	}
	
	// Update is called once per frame
	void Update () {
		if (trigger.on && acid.transform.position.y < targetPosition)
        {
            Vector3 position = new Vector3(0, raiseSpeed, 0) * Time.deltaTime;
            acid.transform.position += position;
        }
	}
}
