using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    
    /*private static GameObject Instance;*/

    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();    
        animator = GetComponent<Animator> ();
        /*if (Instance == null)
        {
            Instance = gameObject;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }*/
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if(!PauseMenu.GameIsPaused)
        {
            move.x = Input.GetAxis ("Horizontal");

            if (Input.GetButtonDown ("Jump") && grounded) 
            {
                velocity.y = jumpTakeOffSpeed;
            } 

            else if (Input.GetButtonUp ("Jump")) 
            {
                if (velocity.y > 0) 
                {
                    velocity.y = velocity.y * 0.5f;
                }
            }

            //rotate player only once
            if (Input.GetKeyDown(KeyCode.A) && left==false)
            {
                transform.Rotate (0f, 180f, 0f);
                left=true;
            }
            if (Input.GetKeyDown(KeyCode.D) && left==true)
            {
                transform.Rotate (0f, 180f, 0f);
                left=false;
            }
            /*if (Input.GetButtonDown("Fire1"))
            {
                fire = true;
            }
            else if (Input.GetButtonUp ("Fire1")) 
            {
                fire = false;
            }

            animator.SetBool ("fire", fire);*/
            animator.SetBool ("leftrun", leftrun);
            animator.SetBool ("grounded", grounded);
            animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }
    }
}