using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Particle {

	public string name;
	public GameObject prefabs;

}

public class ParticleManager : MonoBehaviour
{
	
	[SerializeField] private List<Particle> particles;
	public static ParticleManager instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("More than 1 particle manager");
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}

	public void SpawnParticle(string name, Transform _transform, float duration) {

		for (int i = 0; i < particles.Count; i++) {
			if (particles[i].name == name) {
				GameObject particle = Instantiate(particles[i].prefabs, _transform.position, _transform.rotation);
				Destroy(particle.gameObject, duration);
				return;
			}
		}

		Debug.LogError("No Partcile Given by Name " + name);
		return;
	}

}
