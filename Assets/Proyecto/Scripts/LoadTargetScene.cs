using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadTargetScene : MonoBehaviour {

    public void LoadSceneNum(int num) {

        if (num < 0 || num >= SceneManager.sceneCountInBuildSettings) {
            Debug.LogWarning("Cant Load num" + num + "SceneManager Only has" + SceneManager.sceneCountInBuildSettings + "scenes in BLTSettings");
            return;
        }
        LoadingScreenManager.LoadScene(num);
    }

}
