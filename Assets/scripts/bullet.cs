using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject bulletEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
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
            Destroy(gameObject);
            GameObject effect1 = Instantiate( bulletEffect, transform.position, transform.rotation);
            Destroy(effect1,0.35f);
        }
        if (trig.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
            GameObject effect1 = Instantiate( bulletEffect, transform.position, transform.rotation);
            Destroy(effect1,0.35f);
        }
    }
}
