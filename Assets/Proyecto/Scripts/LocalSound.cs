using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class LocalSound : MonoBehaviour {

    private Transform jugador;
    private Transform PosicionActual;
    public float RangoCercania;
    float cercaniaHorizontalActual;
    private IEnumerator coroutine;

    //random audio source


    public AudioClip[] Clips;
    public AudioMixerGroup output;
    public float pitch;
    public float volume = 1f;


    // Use this for initialization
    void Start () {

        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        PosicionActual = gameObject.transform;


        coroutine = WaitAndPrint(2.5f);
        StartCoroutine(coroutine);

    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            ReproducirSonido();
        }
    }


        // Update is called once per frame
        void ReproducirSonido () {

        if (Mathf.Abs(PosicionActual.position.x) - Mathf.Abs(jugador.position.x) < 0)
        {
 
            cercaniaHorizontalActual = Mathf.Abs(jugador.position.x) - Mathf.Abs(PosicionActual.position.x);
        }
        else {
 
            cercaniaHorizontalActual = Mathf.Abs(PosicionActual.position.x) - Mathf.Abs(jugador.position.x);
        }

        if (cercaniaHorizontalActual < RangoCercania) {
            PlaySound();
        }

	}



    void PlaySound()
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
