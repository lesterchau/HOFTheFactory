using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChasingTrigger : MonoBehaviour {
	public static bool canChasing = false;
    public GameObject enemy;

	void OnTriggerEnter(Collider other) {
		if(other.transform.tag == "Player") {
            enemy.SetActive(true);
            canChasing = true;
			//transform.GetComponent<EnemyNavi> ().enabled = true;
		}
	}

}