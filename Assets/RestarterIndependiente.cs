using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestarterIndependiente : MonoBehaviour {

    private Timer timer;
    public Canvas canvas;

    // Use this for initialization
    void Start () { 

        timer = FindObjectOfType<Timer>();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level" + timer.CurrentLevel);
        canvas.enabled = !canvas.enabled;
    }
}
