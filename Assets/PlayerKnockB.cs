using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockB : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;
    private bool KB;

    // Start is called before the first frame update
    void Start()
    {
        KB = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (KB == true)
        {
            if(KnockFromRight == true)
            {
                playerRb.velocity = new Vector2(-KBForce, KBForce);
            }
            if(KnockFromRight == false)
            {
                playerRb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
        else
        {
            playerRb.velocity = new Vector2(0, 0);
        }
        
        if(KBCounter<=0)
        {
            KB = false;
        }
    }
}
