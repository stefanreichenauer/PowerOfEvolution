﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
	public string name;
	public AudioClip clip;

	[Range(0f, 10f)]
	public float volume = 5f;
	[Range(0f, 10f)]
	public float volumeVariance = 1f;

	[Range(0f, 10f)]
	public float pitch = 4f;
	[Range(0f, 10f)]
	public float pitchVariance = 1f;

	public bool loop = false;

	[HideInInspector]
	public AudioSource source;

}
