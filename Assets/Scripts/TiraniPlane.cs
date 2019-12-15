using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraniPlane : MonoBehaviour , IDamageAble<float>
{
	[SerializeField] private float health;
	public float Health { get => health; set => health = value; }

	public void Damage(float damageTaken) {
		health -= damageTaken;
		if (health <= 0) {
			health = 0;

			AudioManager.instance.PlaySound("Explosion");
			ParticleManager.instance.SpawnParticle("Explosion", transform, 4f);

			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.CompareTag("Ammo")) {
			Damage(collision.transform.GetComponent<Ammo>().Damage);
		}
	}
}
