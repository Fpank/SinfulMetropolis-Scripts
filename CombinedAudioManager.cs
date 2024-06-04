using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CombinedAudioManager : MonoBehaviour
{
    public static CombinedAudioManager instance;    // Singleton instance of the CombinedAudioManager

    public AudioSource[] musicSources;            // Array to hold different music sources
    public AudioSource[] sfxSources;             // Array to hold different sound efffect sources
    public AudioClip[] sfxClips;                // Array to hold different sound effects

    [SerializeField] private AudioMixer audioMixer;         // Reference to the AudioMixer

    private void Awake()                                   // Initialize the CombinedAudioManager
    {
        if (instance == null)                             // Ensure only one instance of the CombinedAudioManager exists
        {
            instance = this;
            DontDestroyOnLoad(gameObject);               // Ensure the CombinedAudioManager persists across scenes
        }
        else                                
        {                       
            Destroy(gameObject);                        // Destroy the current instance if another one already exists
        }

        
       
    }

    // Volume control methods
    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(level) * 20f);
    }

    public void SetSFXVolume(float level)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(level) * 20f);
    }



    // Stop the currently playing music
    public void StopMusic()
    {
        foreach (var musicSource in musicSources)
        {
            musicSource.Stop();
        }
    }

    // Play a sound effect by index
    public void PlaySFX(int index)
    {
        if (index < 0 || index >= sfxClips.Length)
        {
            Debug.LogError("SFX index out of range");
            return;
        }

        foreach (var sfxSource in sfxSources)
        {
            sfxSource.PlayOneShot(sfxClips[index]);
        }
    }
}
