using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float CoolDown;
    float currentTime;
    public float BulletCount;
    private float CountBullet;

    private bool cooling;
    private bool fire;
    
    private string count;
    

    void Start()
    {
        CountBullet = BulletCount;
        currentTime = CoolDown;
        fire=true;
        cooling=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.GameIsPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shoot();
            }
        }
        if (cooling==true)
        {
            Cooldown();
        }
    }

    private void shoot()
    {
        if (fire==true)
        {
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            BulletCount -= 1;
            count = BulletCount.ToString();
            Debug.Log(count);

            if(BulletCount <= 0)
            {
                fire = false;
                cooling = true;
            }
        }
    }

    void Cooldown()
    {
        CoolDown -= 1 * Time.deltaTime;
        
        if (CoolDown <= 0)
        {
            CoolDown = currentTime;
            cooling=false;
            BulletCount= CountBullet;
            fire=true;
        }
    }
}
