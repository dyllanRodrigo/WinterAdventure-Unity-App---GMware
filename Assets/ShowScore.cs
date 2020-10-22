using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShowScore : MonoBehaviour {

    public int monedas;
    private MainMenu mainMenu;

    private Text theText;

    void Start()
    {

        theText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        monedas = PlayerPrefs.GetInt("CurrentScore");
        theText.text = monedas.ToString();
    }

}