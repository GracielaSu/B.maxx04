using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D trig)
    {
        Debug.Log(trig.name);
        if (trig.gameObject.tag == "Player")
        {
            PlayerHealth player = trig.GetComponent<PlayerHealth>();
            if(player != null)
            {
                player.TakeDamage();
            }
        }
    }
}
