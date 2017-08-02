using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSmashTrigger : MonoBehaviour {

    public Light target;
    private lightFlicker targetCode;
    private bool smashed = false;

	// Use this for initialization
	void Start () {
        targetCode = target.GetComponent<lightFlicker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && smashed == false)
        {
            smashed = true;
            targetCode.smash();
        }
    }
}
