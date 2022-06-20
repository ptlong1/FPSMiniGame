using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public float maxHp;
	public float currentHp;
	public event System.Action OnHurt;
	public GameObject deathVFX;
	public event System.Action OnDie;
	public bool destroyAfterDeath = true;
	bool isDead;

	void Start()
	{
		CurrentHp = maxHp;
	}
	public float CurrentHp { 
		get => currentHp;
		set 
		{
			currentHp = value;
			if (currentHp <= 0f) Die(); 
		}
	}

	public void TakeDamage(float vl)
	{
		CurrentHp -= vl;
		if (OnHurt != null) OnHurt();
	}

	void Die() 
	{
		if (isDead) return;
		isDead = true;
		if (deathVFX != null)
		{
			GameObject vfx = Instantiate(deathVFX, transform.position, deathVFX.transform.rotation);
			Destroy(vfx, 2f);
		}
		if (OnDie != null)
		{
			OnDie();
		}
		if (destroyAfterDeath)
			Destroy(gameObject);
	}
}
