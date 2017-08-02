using UnityEngine;

public class BreakWalls : MonoBehaviour {

    private Rigidbody rb;


    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void Update() {
        if (WallTrigger.canBreak) {
            rb.isKinematic = false;
        } else {
            rb.isKinematic = true;
        }

    }
}
