using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Player player;
    public GameObject optionsPanel;
    public GameObject confirmQuitPanel;
    public GameObject pauseMenuPanel;
    private bool options;
    private bool confirmQuit;

    public Button resumeButton;
    public Button optionsButton;
    public Button quitButton;
    public Button yesQuitButton;
    public Button noQuitButton;

    private void OnEnable()
    {
        resumeButton.onClick.AddListener(delegate { resumeButtonPressed(); });
        optionsButton.onClick.AddListener(delegate { optionsButtonPressed(); });
        quitButton.onClick.AddListener(delegate { quitButtonPressed(); });
        yesQuitButton.onClick.AddListener(delegate { yesQuitButtonPressed(); });
        noQuitButton.onClick.AddListener(delegate { exitQuitConfirmation(); });
    }

    public void resumeButtonPressed()
    {
        player.unPause();
    }

    public void optionsButtonPressed()
    {
        optionsPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        options = true;
        player.onTopMenu = false;
    }

    public void quitButtonPressed()
    {
        confirmQuitPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        confirmQuit = true;
        player.onTopMenu = false;
    }
    
    public void yesQuitButtonPressed()
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
