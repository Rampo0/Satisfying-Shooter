using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ARCamera : MonoBehaviour
{
	[SerializeField] private GameObject objectRenderer;
	private void Start()
	{
		//fixing mobile camera
		if (Application.isMobilePlatform) {
			GameObject camParent = new GameObject("CamParent");
			camParent.transform.position = this.transform.position;
			transform.parent = camParent.transform;
			camParent.transform.Rotate(Vector3.right, 90);
		}

		try
		{
			Input.gyro.enabled = true;
		}
		catch (InvalidCastException e) {
			Debug.Log(e.Message);
		}

		// assign camera texture
		WebCamTexture webCamTexture = new WebCamTexture();
		objectRenderer.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
		webCamTexture.Play();

		// fit plane to camera
		float distance = Vector3.Distance(objectRenderer.transform.position, transform.position);
		float height = 2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * distance;
		float width = height * Camera.main.aspect;
		objectRenderer.transform.localScale = new Vector3(width / 10 + 0.5f, 1, height / 10 + 0.5f);
		
	}

	private void Update()
	{
		Quaternion camRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
		transform.localRotation = camRotation;
	}

}
