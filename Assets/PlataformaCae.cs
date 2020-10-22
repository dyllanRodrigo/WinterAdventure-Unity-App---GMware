using UnityEngine;
using System.Collections;

public class PlataformaCae : MonoBehaviour {

    public float velocidad;
    public float tiempoDeReaccion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Time() {
        yield return new WaitForSeconds(tiempoDeReaccion);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidad);
        Destroy(gameObject.GetComponent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            StartCoroutine(Time());
        }
    }
}
