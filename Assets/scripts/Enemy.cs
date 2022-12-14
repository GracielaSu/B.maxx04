using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Greetings from Sid!

//Thank You for watching my tutorials
//I really hope you find my tutorials helpful and knowledgeable
//Appreciate your support.

public class Enemy : MonoBehaviour
{
    #region Public Variables
    
    public Transform rayCast;
    public Transform rayCast2;

    public RobotCount robotCount;
    public RobotCount2 robotCount2;
    public mapcheck mapCheck;
    
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public Transform leftLimit;
    public Transform rightLimit;
    public CapsuleCollider2D capsuleCollider;
    public CapsuleCollider2D capsuleCollider2;
    public RoomHider roomHider;
    public AudioSource deadSound;
    public AudioSource attacksound;
    
    #endregion
    private int DmgAfter = 200;
    #region Private Variables
    private RaycastHit2D hit;
    private RaycastHit2D hit2;
    private Transform target;
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool inRange; //Check if Player is in range
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    private float speed;

    private float time=2;
	private bool count;
    private bool isDead;
    private bool canplay=true;
    public bool map1=false;
    public bool map2=false;
    #endregion

    private bool OnHit;
    public int Health;
    public int DamageTaken;
    public GameObject HitBox;
	public GameObject deathEffect;

    void Start()
    {
        count = false;
        isDead = false;
    }

	public void TakeDamage()
	{
        OnHit = true;
	}

	void Die()
	{
        if(canplay==true)
        {
            deadSound.Play();
            canplay = false;
        }
        
        if(mapCheck.map1==false)
        {
            robotCount.robotDie = true;
        }
        if(mapCheck.map1==true)
        {
            robotCount2.robotDie = true;
        }
        
        isDead = true;
        capsuleCollider.enabled=false;
        capsuleCollider2.enabled=false;
        anim.SetBool("Dead", true);
	}

    void Awake()
    {
        SelectTarget();
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(roomHider.room == true)
        {
            DamageTaken = DmgAfter;
        }
        
        if(isDead == false)
        {
            if(OnHit)
            {
                Health -= DamageTaken;

                if (Health <= 0)
                {
                    Die();
                    count=true;
                }
                OnHit = false;
            }

            if (!attackMode)
            {
                Move();
            }

            if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                SelectTarget();
            }

            if (inRange)
            {
                hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
                hit2 = Physics2D.Raycast(rayCast2.position, transform.right, rayCastLength, raycastMask);
                speed = moveSpeed * 3;
                RaycastDebugger();
            }

            //When Player is detected
            if (hit.collider != null || hit2.collider != null)
            {
                EnemyLogic();
            }
            else if (hit.collider == null || hit2.collider == null)
            {
                inRange = false;
            }

            if (inRange == false)
            {
                speed = moveSpeed;
                StopAttack();
            }
        }

        if(time<=0)
        {
            Debug.Log("Dead");
            time = 2;
            Destroy(gameObject);
            
        }
        if(count == true)
        {
            time -= 1 * Time.deltaTime;
        }
    }


    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            if(isDead == false)
            {
                Flip();
            }
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("Walk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        attacksound.Play();
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not

        HitBox.SetActive(true);
        
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0 && cooling && attackMode)
        {
            
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        HitBox.SetActive(false);
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
            Debug.DrawRay(rayCast2.position, transform.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
            Debug.DrawRay(rayCast2.position, transform.right * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector3.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector3.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        //Ternary Operator
        //target = distanceToLeft > distanceToRight ? leftLimit : rightLimit;

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x) 
        {
            rotation.y = 180;
        }
        else
        {
            Debug.Log("Twist");
            rotation.y = 0;
        }

        //Ternary Operator
        //rotation.y = (currentTarget.position.x < transform.position.x) ? rotation.y = 180f : rotation.y = 0f;

        transform.eulerAngles = rotation;
    }
}
