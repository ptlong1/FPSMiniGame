using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour
{
	public Transform bulletOutcome;
	public Bullet bulletPrefab;
	public Transform gunHead;
	public GameObject shootVFX;
	public GameObject casingPrefab;

	public void Shoot(Vector3 pos, Quaternion rot)
	{
		Instantiate(bulletPrefab, pos, rot);
	}
	public void Shoot()
	{
		Instantiate(bulletPrefab, bulletOutcome.position, bulletOutcome.rotation);
	}
}
