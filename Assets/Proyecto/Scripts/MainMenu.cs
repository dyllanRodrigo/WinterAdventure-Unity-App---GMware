using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public int vidasIniciales=10;
    public int vidasActuales;
    public int monedasActuales;
        
    void Start() {
        vidasActuales = PlayerPrefs.GetInt("PlayerCurrentLives");
       
    }

    void Update() {
        monedasActuales = PlayerPrefs.GetInt("CurrentScore");
    }

    public void LevelSelect()
    {
        if (PlayerPrefs.HasKey("PlayerCurrentLives"))
        {
            return;
        }
        else
        {
            PlayerPrefs.SetInt("PlayerCurrentLives",vidasIniciales);
        }
    }


    public void AgregarVidas(int agregarNoVidas) {

        PlayerPrefs.SetInt("PlayerCurrentLives", vidasActuales += agregarNoVidas);
    }
}
