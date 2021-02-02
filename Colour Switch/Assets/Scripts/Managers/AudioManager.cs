using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Audio Manager is null");

            return _instance;
        }
    }

    public Sound[] sounds;

    private void Awake()
    {
        if(_instance == null)
            _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("MainTheme");
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == soundName);

        if (s == null)
            return;

        Debug.Log("playing" + soundName);
        s.Play();
    }

    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == soundName);

        if (s == null)
            return;

        Debug.Log("stop playing" + soundName);
        s.StopPlaying();
    }
}
