using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Create an array of sound class instances to store every audio clip
    public Sound[] sounds;

    // Static reference to the current AudioManager instance
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        

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

    private void Start()
    {
        Play("StartMenuTheme");
    }

    // Function to play sound
    //
    // params:
    // name = name of the sound
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        // If the sound isn't in our sounds array
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // If the sound isn't in our sounds array
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
