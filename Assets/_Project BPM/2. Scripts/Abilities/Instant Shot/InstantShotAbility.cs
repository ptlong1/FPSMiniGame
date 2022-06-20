using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class InstantShotAbility : MonoBehaviour
{
	[Header("Raycast Attribute")]
	public float length;
	public float radius;
	[Header("Bullet Properties")]
	public float damage;
	public LayerMask whatIsHit;
	public Transform bulletOutcome;
	public AudioSource gunVFX;
	public Transform gunHead;
	public GameObject shootVFX;
	public GameObject impactVFX;
	public GameEvent OnShoot;
	public GameEvent OnCallPrecision;
	public PrecisionTable precisionTable;
	public IntVariable precisionIndex;
	public void Shoot(Vector3 pos, Quaternion rot)
	{
        RaycastHit hit;
		float distanceToObstacle = 0;
		float currentDmg = damage*precisionTable.damageMultiplier[precisionIndex.Value];

		if (Physics.SphereCast(pos, radius, bulletOutcome.forward, out hit, length, whatIsHit))
        {

			// Debug.Log("Bullet hit something" + hit.collider.gameObject.ToString());
            distanceToObstacle = hit.distance;

			Health target = hit.collider.GetComponent<Health>();
			if (target == null)
			{
				return;
			} 
			target.TakeDamage(currentDmg);
			if (impactVFX != null)
			{
				GameObject tmpVFX = Instantiate(impactVFX, hit.point, rot);
				Destroy(tmpVFX, 1f);
			}
			// Debug.Log("Bullet hit");
        }

	}
	public void Shoot()
	{
		if (OnCallPrecision != null)
			OnCallPrecision.Raise();
		if (OnShoot != null)
		{
			OnShoot.Raise();
		}
		Shoot(bulletOutcome.position, bulletOutcome.rotation);
		GameObject tmpVFX = Instantiate(shootVFX, gunHead.position, gunHead.rotation, gunHead);
		Destroy(tmpVFX, 0.3f);
		gunVFX.Play();
	}
}
