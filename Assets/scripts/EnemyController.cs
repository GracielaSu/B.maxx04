using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    public float EnemySpeed;
    public Rigidbody2D EnemyRigid;
    public float Settimer;
    public bool turn=false;
    public bool flip=false;
    public float timer;
    public float RotateSpeed=1;
    // Start is called before the first frame update
    void Start()
    {
        timer=Settimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer > 0 && turn==false)
        {
            EnemyRigid.velocity = new Vector2(EnemySpeed,0f);
        }
        else if(timer<0 && turn==false)
        {
            timer=Settimer;
            turn=true;
            flip=true;
        }
        if (timer > 0 && turn==true)
        {
            EnemyRigid.velocity = new Vector2(-EnemySpeed,0f);
        }
        else if(timer<0 && turn==true)
        {
            timer=Settimer;
            turn=false;
            flip=true;
        }
        if (flip==true)
        {
            transform.Rotate (0f, 180f , 0f) ;
            flip=false;
        }
    }
}
