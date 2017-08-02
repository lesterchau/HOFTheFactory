using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour {

    public static bool canBreak = false;

    void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player") {
            canBreak = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Player") {
            canBreak = false;
        }
    }
}
