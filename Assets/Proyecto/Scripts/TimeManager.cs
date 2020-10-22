using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class TimeManager : MonoBehaviour {


    public float startingTime;

    public Text theText;

    public int tiempoActual;

    public GameObject timeOutScreen;
    private PlatformerCharacter2D controlDeJugador;


    private PauseManager thePauseManager;
    private HealthManager healthmanager;
    private LifeManager lifemanager;


    //sonido
    public GameObject sonidoBG;
    public float pitchTimeOut;

	// Use this for initialization
	void Start () {
        theText = GetComponent<Text>();
        thePauseManager = FindObjectOfType<PauseManager>();
        healthmanager = FindObjectOfType<HealthManager>();
        controlDeJugador = FindObjectOfType<PlatformerCharacter2D>();
        lifemanager = FindObjectOfType<LifeManager>();
    }
	
	// Update is called once per frame
	void Update () {

        if (thePauseManager.isPaused || healthmanager.isDead || Timer.FindObjectOfType<Timer>().haGanado)
           return;

        startingTime -= Time.deltaTime;

        theText.text = "" + Mathf.Round (startingTime);
        tiempoActual = Mathf.RoundToInt(startingTime);

        if (tiempoActual <= 15 && tiempoActual > 1) {
            sonidoBG.GetComponent<AudioSource>().pitch = pitchTimeOut;
            gameObject.GetComponent<Animator>().enabled = true;
        }

        if (tiempoActual <= 0)
        {
            ActivarTimeOut();
        }
    }


    void ActivarTimeOut()
    {
        timeOutScreen.SetActive(true);
        controlDeJugador.gameObject.SetActive(false);
        healthmanager.isDead = true;
        lifemanager.TakeLife();
    }
}
