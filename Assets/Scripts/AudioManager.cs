﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sound
{
	public string name;
	public AudioClip clip;
	[Range(0f, 1f)]
	public float volume = 0.7f;
	[Range(0f, 1.5f)]
	public float pitch = 1f;

	[Range(0f, 0.5f)]
	public float randomValue = 0.1f;
	[Range(0f, 0.5f)]
	public float randomPitch = 0.1f;

	private AudioSource source;
	public bool loop;

	public void SetSource(AudioSource _source)
	{
		source = _source;
		source.clip = clip;
		source.loop = loop;
	}

	public void Play()
	{
		//source.volume = volume * (1 + Random.Range(-randomValue / 2f, randomValue / 2f));
		//source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f)); ;
		source.volume = volume;

		source.Play();

	}

	public void Stop()
	{
		source.Stop();
	}

	public bool isPlay()
	{
		return source.isPlaying;
	}

}


public class AudioManager : MonoBehaviour
{
	private Scene scene;
	public static AudioManager instance;

	private void Awake()
	{
		scene = SceneManager.GetActiveScene();
		
		if (instance != null)
		{
			Debug.Log("More than 1 audio manager");
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}

	[SerializeField]
	Sound[] sounds;

	private void Start()
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
			_go.transform.SetParent(this.transform);
			sounds[i].SetSource(_go.AddComponent<AudioSource>());
		}

		// Play BG Music
		scene = SceneManager.GetActiveScene();
		if (scene.name == "SampleScene")
		{
			JustPlayThisSound("Propeller");
		}

	}

	public void PlaySound(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Play();
				return;
			}
		}
		//no sounds
		Debug.LogWarning("Sound not found in list: " + _name);
	}

	public void JustPlayThisSound(string _name) {
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Play();
			}
			else {
				sounds[i].Stop();
			}
		}
		//no sounds
		//Debug.LogWarning("Sound not found in list: " + _name);
	}

	public void StopSound(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Stop();
				return;
			}
		}
		//no sounds
		Debug.LogWarning("Sound not found in list: " + _name);
	}

	public bool SoundisPlay(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				return sounds[i].isPlay();
			}

		}
		//no sounds
		Debug.LogWarning("Sound not found in list: " + _name);
		return false;
	}

	private void Update()
	{
		
	}

}
