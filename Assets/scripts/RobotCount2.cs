using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RobotCount2 : MonoBehaviour
{
    public Text countUI;
    public int kill;
    public bool robotDie;
    //private Enemy enemy;

    void Start()
    {
       // enemy.map1=true;
    }

    void Update()
    {

        if(robotDie == true)
        {
            reduce();
        }
        countUI.text = kill.ToString();
       // if(kill <= 0)
       // {
            //SceneManager.LoadScene("map1 to map2");
        //}
    }

    void reduce()
    {
        kill = kill - 1;
        robotDie = false;
    }
}
