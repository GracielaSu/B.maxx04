using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHider : MonoBehaviour
{
    public GameObject hider;
    public bool room;
    public GameObject reward;
    public float timer = 2;
    private float time;
    private bool startTime;

    void Start()
    {
        room = false;
        startTime = false;
        time = timer;
        reward.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        
        if(collisionGameObject.name == "Player")
        {
            Debug.Log("Found it!");
            reward.SetActive(true);
            hider.SetActive(false);
            room = true;
            startTime = true;
        }
    }

    void Update()
    {
        if(startTime == true)
        {
            timer -= 1 * Time.deltaTime;
        }
        if(timer <= 0)
        {
            reward.SetActive(false);
            startTime = false;
            timer = time;
        }
    }

}
