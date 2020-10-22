using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

    Canvas canvas;
    public bool isPaused;
    Timer checkLevel;

    private Timer timer;

    //audio effect

     public float frecuenciaMinima;
    public float frecuenciaMaxima;

    private GameObject camera;


    void Start()
    {
        checkLevel = FindObjectOfType<Timer>();

        camera = GameObject.FindGameObjectWithTag("MainCamera");

        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        isPaused = false;

        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && timer.haGanado==false && LifeManager.FindObjectOfType<LifeManager>().haPerdido==false)
        {
            Pause();
        }

        if (isPaused)
        {
            camera.GetComponent<AudioLowPassFilter>().cutoffFrequency = frecuenciaMinima;
        }
        else {
            camera.GetComponent<AudioLowPassFilter>().cutoffFrequency = frecuenciaMaxima;
        }

  
    }

    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
      //  Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        isPaused = !isPaused;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    public void RestartLevel() {
    SceneManager.LoadScene("Level"+checkLevel.CurrentLevel);
        Pause();
    }

    public void MainMenu() {

        SceneManager.LoadScene("Menu Select");
    }
}