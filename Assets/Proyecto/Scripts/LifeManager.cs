using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class LifeManager : MonoBehaviour {


   // public int startingLives;
    private int lifeCounter;


    private Text theText;

    public GameObject gameOverScreen;
    private PlatformerCharacter2D controlDeJugador;
    private HealthManager healthmanager;

    public bool haPerdido;
    private GameObject camera;
    public float frecuenciaMinima;
    public float frecuenciaMaxima;
    public float resonancia;

    // public string mainMenu;
    //    public float waitAfterGameOver;

    // Use this for initialization
    void Start () {

        theText = GetComponent<Text>();

        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");

        controlDeJugador = FindObjectOfType<PlatformerCharacter2D>();
        healthmanager = FindObjectOfType<HealthManager>();
        haPerdido = false;

        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {

        if (lifeCounter <= 0) {
            haPerdido = true;
            ActivarGameOver();
        }

            theText.text = "X " + lifeCounter;

        //     if (gameOverScreen.activeSelf) {
        //         waitAfterGameOver -= Time.deltaTime;
        //    }

        //   if (waitAfterGameOver < 0) {
        //       Application.LoadLevel(mainMenu);
        //  }

        if (haPerdido)
        {
            camera.GetComponent<AudioHighPassFilter>().cutoffFrequency = frecuenciaMaxima;
            camera.GetComponent<AudioHighPassFilter>().highpassResonanceQ = resonancia;
        }
        else
        {
            camera.GetComponent<AudioHighPassFilter>().cutoffFrequency = frecuenciaMinima;
            camera.GetComponent<AudioHighPassFilter>().highpassResonanceQ = 1;
        }

    }

    public void GiveLife() {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }


    public void TakeLife() {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }


    void ActivarGameOver() {
            gameOverScreen.SetActive(true);
            controlDeJugador.gameObject.SetActive(false);
        healthmanager.isDead = true;
    }
}
