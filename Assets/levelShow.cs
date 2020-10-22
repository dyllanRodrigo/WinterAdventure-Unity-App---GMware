using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class levelShow : MonoBehaviour {

    Text estetexto;
    private Timer timer;

	// Use this for initialization
	void Start () {
        timer = FindObjectOfType<Timer>();
        estetexto = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        estetexto.text = "Level  " + timer.CurrentLevel +"  -  15";
	}
}
