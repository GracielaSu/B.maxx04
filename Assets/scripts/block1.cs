using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block1 : MonoBehaviour
{
    public int Block1Force;
    public float BlockSpeed;
    public Rigidbody2D BlockRigidBody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BlockRigidBody.velocity = new Vector2(10f,0f);
        }
    }
}
