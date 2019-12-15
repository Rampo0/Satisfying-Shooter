using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject enemy;
	[SerializeField] private int maxEnemy = 3;
	[SerializeField] private float boxScale = 10f;
	[SerializeField] private float timeSpawn = 5f;

	private void Start()
	{
		StartCoroutine(Spawn());
	}

	private IEnumerator Spawn() {

		while (true) {
			yield return new WaitForSeconds(timeSpawn);
			float randPos = Random.RandomRange(-boxScale, boxScale);
			bool canSpawn = true;
			GameObject[] enemyCounts = GameObject.FindGameObjectsWithTag("Enemy");

			// check other enemy position
			foreach (GameObject enemy in enemyCounts) {
				if (randPos < enemy.transform.position.y + enemy.GetComponent<BoxCollider>().size.y && randPos > enemy.transform.position.y - enemy.GetComponent<BoxCollider>().size.y) {
					canSpawn = false;
				}
			}

			if (enemyCounts.Length < maxEnemy && canSpawn)
			{
				Instantiate(enemy, new Vector3(randPos, randPos, randPos), Quaternion.Euler(new Vector3(0f,Random.RandomRange(0f,360f),0f)));
			}

		}
	}



}
