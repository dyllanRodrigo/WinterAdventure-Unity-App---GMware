using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour {


    private bool puedeComprar=true;
    public int costoDeVida;
    private ShowScore showScore;
    private Showlives showLives;
    // Use this for initialization
    void Start() {
        showScore = FindObjectOfType<ShowScore>();
        showLives = FindObjectOfType<Showlives>();

    }

    // Update is called once per frame
    void Update() {

        if (showScore.monedas < costoDeVida) {
            puedeComprar = false;
        }
        else{
            puedeComprar=true;
        }

    }


    public void ComprarConMonedas() {
        if (puedeComprar) {
            PlayerPrefs.SetInt("CurrentScore",showScore.monedas-=costoDeVida);
            PlayerPrefs.SetInt("PlayerCurrentLives", showLives.lifeCounter += 1);
        }
    }
}
