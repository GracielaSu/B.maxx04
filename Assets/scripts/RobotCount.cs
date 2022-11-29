using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotCount : MonoBehaviour
{
    public Text countUI;
    public int kill;
    public bool robotDie;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(robotDie == true)
        {
            reduce();
        }
        countUI.text = kill.ToString();
    }

    void reduce()
    {
        kill = kill - 1;
        robotDie = false;
    }
}
