using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour {
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    private bool touched = false;


    void Update() {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 6f) {
            hasPlayer = true;
        } else {
            hasPlayer = false;
        }

        if (beingCarried) {
            if (touched) {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            if (Input.GetMouseButtonDown(0)) {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);

            } else if (Input.GetMouseButtonDown(1)) {

                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
        else if (hasPlayer && Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }
    }

    //void RandomAudio() {

    //    if (audio.isPlaying) {
    //        return;
    //    }
    //    audio.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
    //    audio.Play();
    //}

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Pipe") {
            Destroy(gameObject);
        }
        else if (beingCarried) {
                touched = true;
        }
    }
}