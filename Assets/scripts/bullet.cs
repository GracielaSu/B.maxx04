using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float DestroyTime;
    private float timer;
    //private bool destroy;
    public Rigidbody2D rb;
    public GameObject bulletEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        //destroy = false;
        //timer = DestroyTime;
    }

    void FixedUpdate()
    {
        DestroyTime -= 1 * Time.deltaTime;
        if(DestroyTime <= 0)
        {
            DestroyFunc();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        Debug.Log(trig.name);
        if (trig.gameObject.tag == "Enemy")
        {
            Enemy enemy = trig.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage();
            }
            DestroyFunc();
        }
        if (trig.gameObject.tag == "Platform")
        {
            DestroyFunc();
        }
    }

    private void DestroyFunc()
    {
        Destroy(gameObject);
        GameObject effect1 = Instantiate( bulletEffect, transform.position, transform.rotation);
        Destroy(effect1,0.35f);
    }
}
