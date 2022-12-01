using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public Enemy enemy;
    public bool working;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerKnockB player = collision.GetComponent<PlayerKnockB>();
            
            if(player != null)
            {
                if(collision.transform.position.x <= transform.position.x)
                {
                    player.KnockFromRight = true;
                }
                if(collision.transform.position.x > transform.position.x)
                {
                    player.KnockFromRight = false;
                }
                player.KBtrue();
                working = true;
            }
        }
        else
        {
            working = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.Flip();
        }
    }

    
}
