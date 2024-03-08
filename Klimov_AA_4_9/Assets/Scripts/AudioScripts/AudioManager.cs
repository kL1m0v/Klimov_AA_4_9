using System;
using UnityEngine;

namespace Tank1990
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] 
        private Sound[] _musics;
        [SerializeField] 
        private Sound[] _SFXs;
        private static AudioManager _audioManager;
        [SerializeField]
        private AudioSource _musicSource;
        [SerializeField]
        private AudioSource _sfxSource;
        private void Start()
        {
            if (_audioManager == null)
            {
                _audioManager = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static void PlayMusic(string nameOfMusic)
        {
            Sound sound = Array.Find(_audioManager._musics, s => s.name == nameOfMusic);
            if(sound == null)
            {
                Debug.Log("The music was not found");
            }
            else
            {
                _audioManager._musicSource.clip = sound.clip;
                _audioManager._musicSource.Play();
            }
        }

        public static void PlaySFX(string nameOfSFX)
        {
            Sound sound = Array.Find(_audioManager._SFXs, s => s.name == nameOfSFX);
            if(sound == null)
            {
                Debug.Log("The sound was not found");
            }
            else
            {
                _audioManager._sfxSource.clip = sound.clip;
                _audioManager._sfxSource.Play();
            }
        }
    }
}
