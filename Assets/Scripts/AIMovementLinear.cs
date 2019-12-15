using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AIMovementLinear : MonoBehaviour
{
	private Rigidbody rigidbody;
	[SerializeField] private float waitForTurning = 3f;
	[SerializeField] private float speed = 3f;
	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		StartCoroutine(Turning());
	}

	private void FixedUpdate()
	{
		rigidbody.velocity = transform.forward * speed;
	}

	private IEnumerator Turning() {
		while (true)
		{
			yield return new WaitForSeconds(waitForTurning);
			transform.eulerAngles += new Vector3(0f, 180f, 0f);
		}
	}

}
