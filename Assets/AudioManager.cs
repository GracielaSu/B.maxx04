using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource click;
    public AudioSource click2;
    public AudioSource walk;
    public AudioSource shoot;
    public AudioSource die;
    public AudioSource robotmove;
    public AudioSource robotdead;
    public AudioSource robotatk;
    public AudioSource intro1;
    public AudioSource intro2;
   
    

    public AudioClip clip;
    // Update is called once per frame
    public void ClickSound()
    {
        click.Play();
    }
}
