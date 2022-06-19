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
		Bullet newBulelt = Instantiate(bulletPrefab, bulletOutcome.position, bulletOutcome.rotation);
		GameObject tmpVFX = Instantiate(shootVFX, gunHead.position, gunHead.rotation, gunHead);
		Destroy(tmpVFX, 0.3f);
		Destroy(newBulelt.gameObject, 3f);
		gunVFX.Play();
	}
}
