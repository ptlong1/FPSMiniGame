using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class ShootAbility : MonoBehaviour
{
	public Transform bulletOutcome;
	public AudioSource gunVFX;
	public Bullet bulletPrefab;
	public Transform gunHead;
	public GameObject shootVFX;
	public GameObject casingPrefab;
	public GameEvent OnShoot;
	public void Shoot(Vector3 pos, Quaternion rot)
	{
		Instantiate(bulletPrefab, pos, rot);
	}
	public void Shoot()
	{
		if (OnShoot != null)
		{
			OnShoot.Raise();
		}
		Instantiate(bulletPrefab, bulletOutcome.position, bulletOutcome.rotation);
		gunVFX.Play();
	}
}
