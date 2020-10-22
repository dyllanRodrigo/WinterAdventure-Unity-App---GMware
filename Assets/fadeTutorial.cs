using UnityEngine;
using System.Collections;

public class fadeTutorial : MonoBehaviour {

    public GameObject contenedorTutorial;

    public void FadeTutorial() {
        contenedorTutorial.gameObject.GetComponent<Animator>().SetBool("haCerrado", true);
        Destroy(contenedorTutorial,1f);
    }

}
