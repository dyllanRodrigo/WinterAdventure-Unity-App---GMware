using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioSource backGroundMusic;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<AudioManager>().Length > 1) {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeBGM(AudioClip music) {

        if (backGroundMusic.clip.name == music.name)
            return;

        backGroundMusic.Stop();
        backGroundMusic.clip = music;
        backGroundMusic.Play();
    }
}
