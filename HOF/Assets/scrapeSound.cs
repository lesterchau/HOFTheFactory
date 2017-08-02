using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapeSound : MonoBehaviour {

    public float scrapeRate = 3;
    private float scrapeTimer;
    public AudioSource scrape;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > scrapeTimer)
        {
            scrape.Play();
            scrapeTimer = Time.time + scrapeRate;
        }
	}
}
