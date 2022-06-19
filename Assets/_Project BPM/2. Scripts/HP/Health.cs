using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public float maxHp;
	public float currentHp;

	public GameObject deathVFX;
	public event System.Action OnDie;

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
	}

	void Die() 
	{
		if (deathVFX != null)
		{
			GameObject vfx = Instantiate(deathVFX, transform.position, deathVFX.transform.rotation);
			Destroy(vfx, 2f);
		}
		if (OnDie != null)
		{
			OnDie();
		}
		Destroy(gameObject);
	}
}
