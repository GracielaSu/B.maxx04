using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockB : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public Transform rayCastP;
    public LayerMask raycastMask;
    public float rayCastLength;

    private float Timer;
    private RaycastHit2D wallCheck;
    private RaycastHit2D wallCheck2;

    public bool KnockFromRight;
    public bool KB;

    // Start is called before the first frame update
    void Start()
    {
        KB = false;
        Timer = KBCounter;
        wallCheck = Physics2D.Raycast(rayCastP.position, transform.right, rayCastLength, raycastMask);
        wallCheck2 = Physics2D.Raycast(rayCastP.position, -transform.right, rayCastLength, raycastMask);
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Platform")
        {
            target = trig.transform; 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(rayCastP.position, transform.right * rayCastLength, Color.red);
        Debug.DrawRay(rayCastP.position, -transform.right * rayCastLength, Color.red);
        if (KB == true)
        {
            if(KnockFromRight == true)
            {
                //gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2(-KBForce,KBForce) * Time.deltaTime);
                //gameObject.transform.Translate(new Vector2(-KBForce,KBForce) * Time.deltaTime);
                playerRb.velocity = new Vector2(-KBForce, KBForce);
            }
            if(KnockFromRight == false)
            {
                //gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2(-KBForce,KBForce) * Time.deltaTime);
                //gameObject.transform.Translate(new Vector2(KBForce,-KBForce) * Time.deltaTime);
                playerRb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
        else
        {
            //gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2(0,0) * Time.deltaTime);
            //gameObject.transform.Translate(new Vector2(0,0) * Time.deltaTime);
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

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Platform")
        {
            KB = false;
            KBCounter = Timer;
            //gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2(0,0) * Time.deltaTime);
            //gameObject.transform.Translate(new Vector2(0,0) * Time.deltaTime);
            playerRb.velocity = new Vector2(0, 0);
            Debug.Log("wall!");
        }
    }*/
}
