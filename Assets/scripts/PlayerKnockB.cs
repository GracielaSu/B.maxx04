using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockB : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    private float Timer;

    public bool KnockFromRight;
    public bool KB;

    // Start is called before the first frame update
    void Start()
    {
        KB = false;
        Timer = KBCounter;
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
            KBCounter = Timer;
        }
    }

    public void KBtrue()
    {
        KB = true;
    }
        
}
