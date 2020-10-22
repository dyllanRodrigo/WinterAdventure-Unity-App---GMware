using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundKeeper : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 17 || SceneManager.GetActiveScene().buildIndex == 18)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
