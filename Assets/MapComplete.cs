using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapComplete : MonoBehaviour
{
    public string SceneToContinue;
    public string SceneToMainmenu;

    public void Continue()
    {
        SceneManager.LoadScene(SceneToContinue);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(SceneToMainmenu);
    }
}
