using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    public string SceneToLoad;
    public RobotCount2 robotCount;
    public GameObject killAllWarning;
    public GameObject TextBg;

    private float timer = 2;
    private float time;
    private bool startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = false;
        time = timer;
        killAllWarning.SetActive(false);
        TextBg.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger work");
        GameObject collisionGameObject = collision.gameObject;
        
        if(collisionGameObject.name == "Player")
        {
            Debug.Log("Player detected");
            if(robotCount.kill <= 0)
            {
                LoadScene();
            }
            else
            {
                Debug.Log("else working");
                killAllWarning.SetActive(true);
                TextBg.SetActive(true);
                startTime = true;
            }
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    
    void Update()
    {
        if(startTime == true)
        {
            timer -= 1 * Time.deltaTime;
        }
        
        if(timer <= 0)
        {
            killAllWarning.SetActive(false);
            TextBg.SetActive(false);
            startTime = false;
            timer = time;
        }
        Debug.Log("C is working");
    }
}
