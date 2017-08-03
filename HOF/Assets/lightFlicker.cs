using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker : MonoBehaviour {

    private Light spotLight;
    private bool Flickering = false;
    private bool on = true;
    private float flickerTimer;
    private float pauseTimer;
    public float flickerSpeed = 0.05f;
    public float pauseRate = 1;
    public AudioSource smashSound;

	// Use this for initialization
	void Start () {
        spotLight = GetComponent<Light>();
        pauseTimer = Time.time + pauseRate;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (on)
        {
            if (Time.time < pauseTimer)
            {

                if (Flickering && Time.time > flickerTimer)
                {
                    if (spotLight.enabled)
                    {
                        spotLight.enabled = false;
                    }
                    else
                    {
                        spotLight.enabled = true;
                    }
                    flickerTimer = Time.time + flickerSpeed;
                }
            }
            else
            {
                if (Flickering)
                {
                    Flickering = false;
                    spotLight.enabled = true;
                }
                else
                {
                    Flickering = true;
                }
                pauseTimer = Time.time + pauseRate;
            }
        }
	}

    public void smash()
    {
        on = false;
        spotLight.enabled = false;
        smashSound.Play();
    }
}
