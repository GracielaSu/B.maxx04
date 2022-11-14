using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string SceneToPlay;
    public string SceneToTutorial;

    public void playGame()
    {
        Debug.Log("Play.");
        SceneManager.LoadScene(SceneToPlay);
    }

    public void playTutorial()
    {
        Debug.Log("Tutorial.");
        SceneManager.LoadScene(SceneToTutorial);
    }

    public void QuitGame()
	{
        Debug.Log("Quit.");
		Application. Quit();
	}
}
