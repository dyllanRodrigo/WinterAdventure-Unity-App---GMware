using UnityEngine;
using System.Collections;

public class plataformaDesaparece : MonoBehaviour {

    public float tiempoDeReaccion;
   
    void Start() {

    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(tiempoDeReaccion);
        gameObject.GetComponent<Animator>().enabled = true;
        Destroy(gameObject,1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Time());
        }
    }


}
