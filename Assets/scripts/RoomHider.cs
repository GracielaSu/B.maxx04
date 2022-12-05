using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHider : MonoBehaviour
{
    public GameObject hider;
    public bool room;

    void Start()
    {
        room = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        
        if(collisionGameObject.name == "Player")
        {
            Debug.Log("Found it!");
            hider.SetActive(false);
            room = true;
        }
    }
}
