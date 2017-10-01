using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound [] sEffects;
    // Use this for initialization

    void Awake () {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        

        foreach (Sound s in sEffects)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
        }	
	}
	
	public void Play (string name)
    {
        Sound s1 = Array.Find(sEffects, sound => sound.name == name);
        if (s1 == null)
        {
            Debug.LogWarning("Whooops: " + name + "isn't exist!");
            return;
        }
        s1.source.Play();
    }
}
