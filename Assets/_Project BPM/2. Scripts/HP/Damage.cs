using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
	public float damage;
	
	void DealDamage(Health target, float vl)
	{
		target.TakeDamage(vl);
	}
}
