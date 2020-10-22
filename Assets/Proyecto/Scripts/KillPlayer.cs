using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManagerGame levelManagerGame;

	// Use this for initialization
	void Start () {
        levelManagerGame = FindObjectOfType<LevelManagerGame>();
         
	}
	
	// Update is called once per frame
	void Update () {

        }
    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag =="Player") {
            levelManagerGame.RespawnPlayer();
        }

    }
}
