using UnityEngine;
using System.Collections;


public class CercaniaPlayer : MonoBehaviour
{

    private Transform jugador;
    private Transform PosicionActual;
    public float RangoCercania;
    float cercaniaHorizontalActual;
    public GameObject particulas;
    public GameObject particulasGano;
    AudioSource winSound;
    public GameObject mainBGMusic;


    // Use this for initialization
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        PosicionActual = gameObject.transform;

        winSound = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (Mathf.Abs(PosicionActual.position.x) - Mathf.Abs(jugador.position.x) < 0)
        {

            cercaniaHorizontalActual = Mathf.Abs(jugador.position.x) - Mathf.Abs(PosicionActual.position.x);
        }
        else
        {

            cercaniaHorizontalActual = Mathf.Abs(PosicionActual.position.x) - Mathf.Abs(jugador.position.x);
        }

        if (cercaniaHorizontalActual < RangoCercania && particulasGano.activeSelf==false)
        {
            particulas.SetActive(true);
        }
        else{
            particulas.SetActive(false);
        }

    }


    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {
            particulasGano.SetActive(true);
            winSound.Play();
            mainBGMusic.GetComponent<AudioSource>().mute = true;
            particulas.SetActive(false);
        }

    }

}
