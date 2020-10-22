using UnityEngine;
using System.Collections;

public class CercaniaPlayerZombie : MonoBehaviour{

    private Transform jugador;
    private Transform PosicionActual;
    public float RangoCercania;
    float cercaniaHorizontalActual;
    public GameObject zombie;

    // Use this for initialization
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        PosicionActual = gameObject.transform;
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

        if (cercaniaHorizontalActual < RangoCercania && zombie.activeSelf == false)
        {
            zombie.SetActive(true);
        }


        if (cercaniaHorizontalActual < RangoCercania+10)
        {
            zombie.GetComponent<AudioSource>().volume = 0.3f;
        }
        else {
            zombie.GetComponent<AudioSource>().volume = 0f;
        }
         
        }

    }

