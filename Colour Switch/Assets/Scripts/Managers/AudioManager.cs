using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
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
        public bool musicPlaying = true;
        public bool mainMusicPlaying = true;
        public bool secondaryMusicPlaying = true;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        public void Play(string soundName)
        {
            Sound s = Array.Find(sounds, sound => sound.soundName == soundName);

            if (s == null)
                return;

            //Debug.Log("playing" + soundName);
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

        public Sound GetSound(string soundName)
        {
            Sound s = Array.Find(sounds, sound => sound.soundName == soundName);

            return s;
        }

        public void ReduceVolume(string soundName)
        {
            Sound s = Array.Find(sounds, sound => sound.soundName == soundName);
            s.volume = 0;
        }
        public void StopMusic()
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                if (mainMusicPlaying)
                {
                    Stop("MainTheme");
                    mainMusicPlaying = false;
                    secondaryMusicPlaying = false;
                }
                else if (!mainMusicPlaying)
                {
                    Play("MainTheme");
                    mainMusicPlaying = true;
                    secondaryMusicPlaying = true;
                }
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (mainMusicPlaying)
                {
                    Stop("MainTheme");
                    mainMusicPlaying = false;
                    secondaryMusicPlaying = false;
                }
                else if (!mainMusicPlaying)
                {
                    Play("MainTheme");
                    mainMusicPlaying = true;
                    secondaryMusicPlaying = true;
                }
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                if (secondaryMusicPlaying)
                {
                    Stop("SecondaryTheme");
                    secondaryMusicPlaying = false;
                    mainMusicPlaying = false;
                }
                else if (!secondaryMusicPlaying)
                {
                    Play("SecondaryTheme");
                    secondaryMusicPlaying = true;
                    mainMusicPlaying = true;
                }
            }
        }
    }
}
