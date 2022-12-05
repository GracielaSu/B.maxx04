using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotCount : MonoBehaviour
{
    public Text countUI;
    public int kill;
    public bool robotDie;
    public Animator CageAnim;
    public Animator CasseAnim;
    public Animator PlayerAnim;
    public GameObject player;
    public Vector2 FinalPostion;
    
    
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
        if(kill <= 0)
        {
            CageAnim.SetBool("win", true);
            CasseAnim.SetBool("win", true);
            PlayerAnim.SetBool("win", true);
            player.transform.position = FinalPostion;
            player.transform.Rotate(0,0,0);
        }
    }

    void reduce()
    {
        kill = kill - 1;
        robotDie = false;
    }
}
