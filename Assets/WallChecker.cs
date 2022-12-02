using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public bool wall;
    // Start is called before the first frame update
    void Start()
    {
        wall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessCollision(collision.gameObject);
    }

    void OnConllisionEnter2D(Collision2D collision)
    {
        ProcessCollision(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        wall = false;
    }

    void ProcessCollision(GameObject collider)
    {
        if (collider.CompareTag("Platform"))
        {
            wall = true;
        }
    }
}
