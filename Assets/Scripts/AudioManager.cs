using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // the game volume when starting the game
    public static float masterVolume = 0.5f;

    // Create an array of sound class instances to store every audio clip
    public Sound[] sounds;

    // Static reference to the current AudioManager instance
    public static AudioManager instance;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // If there is a masterVolume saved in PlayerPrefs
        if (PlayerPrefs.HasKey("masterVolume")) {
            masterVolume = PlayerPrefs.GetFloat("masterVolume");
        }

        // Set game volume to the master volume
        AudioListener.volume = masterVolume;

        // Dont Destroy when changing scenes
        DontDestroyOnLoad(gameObject);

        // Load the audio clips and add audio source for each clip
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        Play("StartMenuTheme");
    }

    /// <summary>
    /// Function to play a sound
    /// </summary>
    /// <param name="soundName">the name of the sound</param>
    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        
        // If the sound isn't in our sounds array
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found!");
            return;
        }
        s.source.Play();
    }

    /// <summary>
    /// Function to stop a sound
    /// </summary>
    /// <param name="soundName">the name of the sound</param>
    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        // If the sound isn't in our sounds array
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found!");
            return;
        }
        s.source.Stop();
    }

    // Resets the volume
    public void ResetVolume()
    {
        AudioListener.volume = masterVolume;
    }
}
