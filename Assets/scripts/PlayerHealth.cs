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
	
	private bool OnHit;

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
			}
			OnHit = false;
		}
		
	}

	void Die ()
	{
		Destroy(gameObject);
        SceneManager.LoadScene(RespawnScene);
	}

}
