using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;


    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixer;
            

            
        }
        
    }

 
   public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("[AudioManager] Nie znaleziono takiego dzwieku: " + s.name);
            return;
        }
        s.source.Play();
    }

    public void Stop()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
       
    }
}
