using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShowBannerOnLoad : MonoBehaviour {

    void Awake() {
        if(SceneManager.GetActiveScene().buildIndex == 17)
        AdmobAdManager.Instance.ShowBanner();
    }

  
}
