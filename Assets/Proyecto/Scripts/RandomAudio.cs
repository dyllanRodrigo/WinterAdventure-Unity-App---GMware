using UnityEngine;
using System.Collections;
using UnityEngine.Audio;


public class RandomAudio : MonoBehaviour {

    public AudioClip[] Clips;
    public AudioMixerGroup output;
    public float pitch;
    public float volume = 1f;

    void Update()
    {

    }

    public void PlaySound()
    {

        int randomClip = Random.Range(0, Clips.Length);
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = Clips[randomClip];

        source.outputAudioMixerGroup = output;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();

        Destroy(source, Clips[randomClip].length);
    }
}

