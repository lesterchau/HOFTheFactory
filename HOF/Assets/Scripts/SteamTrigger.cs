using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTrigger : MonoBehaviour {

    public static bool isLeaking = false;
    public GameObject SteamLeaking;

    private void Update() {
        if (isLeaking)
            SteamLeaking.SetActive(true);
    }


    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            isLeaking = true;
        }
    }
}
