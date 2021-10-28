using UnityEngine.Audio;
using System;   
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.playOnAwake = sound.playOnAwake;
        }
    }

   public void Play(string name)
    {
        Sound soundToPlay = Array.Find(sounds, sound => sound.name == name);
        if (soundToPlay == null) return;
        soundToPlay.source.Play();
        
    }

   public void Stop(string name)
    {
        Sound soundToStop = Array.Find(sounds, sound => sound.name == name);
        if (soundToStop == null) return;
        soundToStop.source.Stop();
    }

    public void SetVolume(string name, float volume)
    {
        if (volume > 1f) volume = 1f;
        if (volume < 0f) volume = 0f;
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null) return;

        sound.source.volume = volume;

    }

    public void SetPitch(string name, float pitch)
    {
        if (pitch < -3) pitch = -3;
        if (pitch > 3) pitch = 3;
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null) return;

        sound.source.pitch = pitch;
    }

    public float GetLength(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null) return -1;

        return sound.source.clip.length;

    }

    public bool IsPlaying(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null) return false;

        return sound.source.isPlaying;
    }
}
