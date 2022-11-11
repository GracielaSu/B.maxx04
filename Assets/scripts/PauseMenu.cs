using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingUI;
    public GameObject healthbarUI;
    public string RestartScene;
    public string MainMenu;
    
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        healthbarUI.SetActive(true);
        settingUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    public void Pause()
    {
        settingUI.SetActive(false);
        healthbarUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(RestartScene);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(MainMenu);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}