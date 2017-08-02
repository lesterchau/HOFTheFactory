using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    public Transform enemyPos;
    public static int spawner = 0;

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            if (spawner <= 0) {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Instantiate(enemy, enemyPos.position, enemyPos.rotation);
                spawner += 1;
            }
        }
    }
}