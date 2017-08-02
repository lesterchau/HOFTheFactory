using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;


public class EnemyNavi : MonoBehaviour {

    public GameObject TargetObject;
    private NavMeshAgent navMeshAgent;
    Animator animator;
    private bool run;
    private float attackTimer;
    public float attackRate = 2;
    public AudioSource slash;


    void Start() {
        animator = GetComponent<Animator>();
		navMeshAgent = GetComponent<NavMeshAgent>();
        TargetObject = GameObject.FindGameObjectWithTag("Player");

    }

    void Update() {
		
		if (ChasingTrigger.canChasing) {
			transform.GetComponent<NavMeshAgent> ().enabled = true;
			animator.Play ("Run"); 
		} else {
			animator.Play ("Idle");
		}
		navMeshAgent.destination = TargetObject.transform.position;          
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            run = false;
            if (Time.time > attackTimer)
            {
                animator.Play("Slash");
                TargetObject.GetComponent<Player>().takeDamage(1);
                attackTimer = Time.time + attackRate;
                slash.Play();
            }
        }else {
            run = true;
        }
    }

}