using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	public float force;
	public MeshRenderer bulletRenderer;
	Damage damage;
	Health health;
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		// rb.AddForce(transform.forward*force, ForceMode.VelocityChange);
		rb.velocity = transform.forward*force;
		damage = GetComponent<Damage>();
		health = GetComponent<Health>();
		// meshRenderer = GetComponentInChildren<MeshRenderer>();
		bulletRenderer.enabled = false;
		StartCoroutine(CR_Appear(0.1f));
    }

	IEnumerator CR_Appear(float t)
	{
		yield return new WaitForSeconds(t);
		bulletRenderer.enabled = true;
	}


	
	private void OnTriggerEnter(Collider other) {
		// Debug.Log("Bullet hit");
		Health target = other.GetComponent<Health>();
		if (target == null)
		{
			health.TakeDamage(1);
			return;
		} 
		target.TakeDamage(damage.damage);
		health.TakeDamage(1);
		Debug.Log("Bullet hit");
	}
}
