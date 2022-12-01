using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
	public float TakeDamageValue;
	public string RespawnScene;
	public Animator anim;
	
	private bool OnHit;
	private float timer=3;
	private bool count;
	
	void Start()
	{
		count = false;
	}

    public void TakeDamage ()
	{
		OnHit = true;
	}

	void FixedUpdate()
	{
		if (OnHit)
		{
			CurrentHealth -= TakeDamageValue;

			if (CurrentHealth <= 0)
			{
				Die();
				count=true;
				
			}
			OnHit = false;
		}
		
		if(timer<=0)
		{
			Debug.Log("Dead");
			Destroy(gameObject);
			timer = 3;
			SceneManager.LoadScene(RespawnScene);
			PauseMenu.GameIsPaused = false;
		}
		if(count == true)
		{
			timer -= 1 * Time.deltaTime;
		}
	}

	void Die ()
	{
		PauseMenu.GameIsPaused = true;
		anim.SetBool("die", true);
	}

}
