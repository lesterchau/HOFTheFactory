using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macheteHallway : MonoBehaviour {

    public bool activated = false;
    private bool soundPlayed = false;

    private float pauseTimer;
    public float pauseTime = 1;
    public float movementDistance = 2;
    public float stabSpeed = 0.5f;

    public AudioSource stabSound;

    public GameObject stopper;

    //0 = stab, 1 = back, 2 = move
    private float stage = 0;

    private Vector3 origionalPosition;
    

	// Use this for initialization
	void Start () {
        origionalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated)
        {
            //stab the machete through the wall
            if (stage == 0)
            {
                if (!soundPlayed)
                {
                    stabSound.Play();
                    soundPlayed = true;
                }
                if (transform.position.z < stopper.transform.position.z)
                {
                    transform.position += new Vector3(0, 0, stabSpeed) * Time.deltaTime;
                }
                else
                {
                    stage = 1;
                }
            }
            //withdraw the machete
            else if (stage == 1)
            {
                soundPlayed = false;
                if (transform.position.z > origionalPosition.z)
                {
                    transform.position += new Vector3(0, 0, -stabSpeed *0.8f) * Time.deltaTime;
                }
                else
                {
                    stage = 2;
                    pauseTimer = Time.time + pauseTime;
                }
            }
            //move machete to next location
            else if (stage == 2)
            {
                if (Time.time > pauseTimer)
                {
                    transform.position += new Vector3(movementDistance, 0, 0);
                    stage = 0;
                    if (transform.position.x < stopper.transform.position.x)
                    {
                        activated = false;
                    }
                }

            }
        }
	}

    public void activate()
    {
        activated = true;
    }
}
