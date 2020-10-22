using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class Showlives : MonoBehaviour {


    // public int startingLives;
    public int lifeCounter;


    private Text theText;

    void Start()
    {

        theText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
        theText.text = "X " + lifeCounter;
    }

}
