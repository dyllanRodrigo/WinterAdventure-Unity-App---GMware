using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class WinManager : MonoBehaviour {

    Canvas canvas;

    Timer checkLevel;

    void Start()
    {
        checkLevel = FindObjectOfType<Timer>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void MostrarCanvas()
    {
        canvas.enabled = !canvas.enabled;
        //Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }


    public void RestartLevel()
    {
       SceneManager.LoadScene("Level" + checkLevel.CurrentLevel);
        MostrarCanvas();

    }

    public void MainMenu()
    {

       SceneManager.LoadScene("Menu Select");
        MostrarCanvas();
    }

    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

}