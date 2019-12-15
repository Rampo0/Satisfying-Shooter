using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShooter : MonoBehaviour
{
	[SerializeField] private GameObject ammoPrefab;
	[SerializeField] private float fireRate = 0.5f ;
	private float lastShoot = 0f;
	private bool isShooting = false;
	[SerializeField] private Transform spawnPoint;

	private void Shoot() {
		// Mouse shooting, touch and button click shooting
		if ((Input.GetButton("Fire1") || isShooting || TryGetTouch(out bool getTouch)) && Time.time > lastShoot)
		{
			GameObject bulletClone = Instantiate(ammoPrefab, spawnPoint.position + (transform.forward * 1.1f ), spawnPoint.rotation);
			lastShoot = fireRate + Time.time;
			Destroy(bulletClone, 1);

			AudioManager.instance.PlaySound("Shoot");
			return;
		}
		isShooting = false;
	}

	// Add this function to Button Listener
	public void ButtonToShoot() { isShooting = true; }

	private void Update()
	{
		Shoot();
	}

	private bool TryGetTouch(out bool getTouch) {

		if (Input.touchCount > 0) {
			getTouch = true;
			return true;
		}

		getTouch = false;
		return false; 
	}


}
