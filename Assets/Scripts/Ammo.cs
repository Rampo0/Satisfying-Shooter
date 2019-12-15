using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ammo : MonoBehaviour
{
	private Rigidbody rigidbody;
	[SerializeField] private float damage;
	[SerializeField] private float speed = 10f;

	public float Damage { get => damage; set => damage = value; }

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		rigidbody.useGravity = false;
	}

	private void FixedUpdate()
	{
		rigidbody.velocity = transform.forward * speed;
	}

	private void OnCollisionEnter(Collision collision)
	{
		ParticleManager.instance.SpawnParticle("TinyExplosion", this.transform, 1.5f);
		Destroy(this.gameObject);
	}


}
