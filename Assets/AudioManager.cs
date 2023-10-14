using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    [SerializeField]GameObject ball;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            ball = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        PlayMusic("Dream");
    }

    public void PlayMusic(string name)
    {

        Sound music = Array.Find(musicSounds, x => x.name == name);

        if (music == null)
        {
            Debug.Log("Sound not Found!");

        }
        else
        {
            musicSource.clip = music.clip;
            musicSource.Play();

            Debug.Log("Now Playing: " + music.name);
        }
    }
    public void PlaySFX(string name)
    {
        Sound sfx = Array.Find(sfxSounds, x => x.name == name);

        if (sfx == null)
        {
            Debug.Log("Sound not Found!");

        }
        else
        {
            sfxSource.clip = sfx.clip;
            sfxSource.PlayOneShot(sfxSource.clip);
        }
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void MusicVolume(float volume)
    {
        
        musicSource.volume = volume / 10;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume / 10;
        ball.GetComponent<AudioSource>().volume = sfxSource.volume * 10;
    }
    //as music and sfx files are both very loud originally, division by 10 gives a good range for volume pleasant for gameplay


    

    public void MasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }

}
