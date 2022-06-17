using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	public float force;
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		// rb.AddForce(transform.forward*force, ForceMode.VelocityChange);
		rb.velocity = transform.forward*force;
    }
}
