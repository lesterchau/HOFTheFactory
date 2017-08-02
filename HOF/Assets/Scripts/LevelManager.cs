using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void exit()
    {
        Application.Quit();
    }

    public void loadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
