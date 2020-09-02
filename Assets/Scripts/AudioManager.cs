using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

[RequireComponent(typeof( AudioSource))]
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private AudioSource source;

    //choose the volume and pitch for the Audio
    [Range(0f, 1f)] public float volume;
    [Range(0.1f, 3f)] public float pitch;

    void Awake()
    {
        source=GetComponent<AudioSource>();
        source.volume = volume;
        source.pitch  = pitch;     
    }

    public void Play(int id)
    {
        //Playing Random Sound in Corresponding AudioClips
        source.PlayOneShot(sounds[id].clip[Random.Range(0, sounds[id].clip.Length)]);
    }
}

[System.Serializable]
public class Sound
{
    //word Name
    public string name;

    //Vowel id
    public int id;

    //Number of audio clips per word
    public AudioClip[] clip;

}