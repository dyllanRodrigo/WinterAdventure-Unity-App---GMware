using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class AplicationQUIT : MonoBehaviour {

    public GameObject panelSalir;

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (panelSalir.activeSelf)
            {
                panelSalir.SetActive(false);
            }
            else {
                panelSalir.SetActive(true);
            }
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
