using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneToLoad;
    public RobotCount robotCount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        
        if(collisionGameObject.name == "Player")
        {
            if(robotCount.kill <= 0)
            {
                LoadScene();
            }
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
