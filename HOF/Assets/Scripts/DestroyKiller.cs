using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyKiller : MonoBehaviour {

    public GameObject enemy;

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            Destroy(enemy);
        }
            
    }
}
