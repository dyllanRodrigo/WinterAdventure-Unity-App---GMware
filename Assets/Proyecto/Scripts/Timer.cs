using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {

    public int score;

    private int NivelesEnTotal = 30;//numero de niveles en total   //levelAmount
    public int CurrentLevel;
    private TimeManager timeManager;
    public bool haGanado;

    private WinManager winmanager;

    private Platformer2DUserControl controladorPersonaje;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    int NextLevel;

    void Start() {
        haGanado = false;
        CheckCurrentLevel();
        //  PlayerPrefs.SetInt("Level2", 1); //coloca datos al finalizar el nivel para guarar como terminado y desbloquear siguiente
        // PlayerPrefs.SetInt("Level1_score", score);
        timeManager = FindObjectOfType<TimeManager>();
        NextLevel = CurrentLevel + 1;

        winmanager = FindObjectOfType<WinManager>();

        controladorPersonaje = FindObjectOfType<Platformer2DUserControl>();
    }


    IEnumerator Time() {
        yield return new WaitForSeconds(5f);

        if (score >= 1)
        {
            star1.SetActive(true);
        }
        if (score >= 40)
        {
            star2.SetActive(true);
        }
        if (score >= 80) {
            star3.SetActive(true);
        }

        winmanager.MostrarCanvas();
    }


    void CheckCurrentLevel() {
        for (int i = 1; i < NivelesEnTotal; i++) {
            if (Application.loadedLevelName == "Level" + i) {
                CurrentLevel = i;
            }
        }

    }
    void SaveMyGame() {
      
        if (NextLevel < NivelesEnTotal)
        {
            PlayerPrefs.SetInt("Level" + NextLevel.ToString(), 1);//Desbloqueo del siguiente nivel
            PlayerPrefs.SetInt("Level" + CurrentLevel.ToString() + "_score", score);
        }
        else {

            PlayerPrefs.SetInt("Level" + CurrentLevel.ToString() + "_score", score);
        }
    }

    void Update() {
        score = timeManager.tiempoActual;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player")
        {
            StartCoroutine(Time());
            haGanado = true;

            controladorPersonaje.enabled = false;

            PlayerPrefs.SetInt("Level2", 1);
            PlayerPrefs.SetInt("Level1_score", score);
            SaveMyGame();
        }
    }

    public void LoadNextLevel(int num)
    {
        num = NextLevel;
        //winmanager.Pause();
        if (num < 0 || num >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Cant Load num" + num + "SceneManager Only has" + SceneManager.sceneCountInBuildSettings + "scenes in BLTSettings");
            return;
        }
        LoadingScreenManager.LoadScene(num);
    }


}
