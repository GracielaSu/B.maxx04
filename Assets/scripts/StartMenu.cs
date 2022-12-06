using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string SceneToPlay;
    public GameObject canvas1;
    public GameObject canvas2;
    

    void Start()
    {
        canvas2.SetActive(false);
        canvas1.SetActive(true);
    }

    public void playGame()
    {
        Debug.Log("Play.");
        SceneManager.LoadScene(SceneToPlay);
    }

    public void playTutorial()
    {
        Debug.Log("Tutorial.");
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void QuitGame()
	{
        Debug.Log("Quit.");
		Application. Quit();
	}

    public void BackToMenu()
    {
        Debug.Log("back to menu.");
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }
}
