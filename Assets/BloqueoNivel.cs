using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BloqueoNivel : MonoBehaviour {

    CanvasGroup thiscanvas;
    int vidasActuales;
    public GameObject info;

	// Use this for initialization
	void Start () {
        thiscanvas = GetComponent<CanvasGroup>();
       vidasActuales = PlayerPrefs.GetInt("PlayerCurrentLives");
    }
	
	// Update is called once per frame
	void Update () {

        if (vidasActuales <= 0)
        {
            thiscanvas.interactable = false;
            info.SetActive(true);
        }
        else {
            info.SetActive(false);
        }



	}
}
