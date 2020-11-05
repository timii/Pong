using UnityEngine.Audio;
using UnityEngine;

// So the class appears in the inspector
[System.Serializable]

// Base class for every audio clip
public class Sound
{
    // Name of the audio clip
    public string name;

    // The audio file clip itself
    public AudioClip clip;

    // To give the attributes sliders
    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    // The audio source component of each sound
    public AudioSource source;
}
