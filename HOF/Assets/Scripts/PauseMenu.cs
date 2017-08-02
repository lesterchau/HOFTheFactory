using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public Player player;
    public GameObject optionsPanel;
    public GameObject confirmQuitPanel;
    public GameObject pauseMenuPanel;
    private bool options;
    private bool confirmQuit;

    public void resumeButton()
    {
        player.unPause();
    }

    public void optionsButton()
    {
        optionsPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        options = true;
        player.onTopMenu = false;
    }

    public void quitButton()
    {
        confirmQuitPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        confirmQuit = true;
        player.onTopMenu = false;
    }
    
    public void confirmQuitButton()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (options)
            {
                exitOptions();
            }

            else if (confirmQuit)
            {
                exitQuitConfirmation();
            }
        }
    }

    public void exitOptions()
    {
        optionsPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        player.onTopMenu = true;
        options = false;
    }

    public void exitQuitConfirmation()
    {
        confirmQuitPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        player.onTopMenu = true;
        confirmQuit = false;
    }

}
