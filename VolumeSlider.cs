using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // References to the volume sliders

    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;

    private void Start()                                                   // Initialize the volume sliders
    {
                                                                         // Load saved volume settings
        float musicVolume = PlayerPrefs.GetFloat("Music", 1f);          // Default value
        float sfxVolume = PlayerPrefs.GetFloat("SFX", 1f);             // Default value
        float masterVolume = PlayerPrefs.GetFloat("Master", 1f);      // Default value

        // Set initial values

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
        masterSlider.value = masterVolume;

        // Apply the initial volume settings

        CombinedAudioManager.instance.SetMusicVolume(musicVolume);
        CombinedAudioManager.instance.SetSFXVolume(sfxVolume);
        CombinedAudioManager.instance.SetMasterVolume(masterVolume);

        // Add listeners to update volume and save settings

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    private void SetMusicVolume(float value)                        // Set the music volume
    {
        CombinedAudioManager.instance.SetMusicVolume(value);       // Set the music volume using the CombinedAudioManager
        PlayerPrefs.SetFloat("Music", value);                     // Save the music volume to PlayerPrefs
    }

    private void SetSFXVolume(float value)                          // Set the SFX volume
    {
        CombinedAudioManager.instance.SetSFXVolume(value);         // Set the SFX volume using the CombinedAudioManager
        PlayerPrefs.SetFloat("SFX", value);                       // Save the SFX volume to PlayerPrefs
    }

    private void SetMasterVolume(float value)                        // Set the master volume
    {
        CombinedAudioManager.instance.SetMasterVolume(value);       // Set the master volume using the CombinedAudioManager
        PlayerPrefs.SetFloat("Master", value);                     // Save the master volume to PlayerPrefs
    }

}
