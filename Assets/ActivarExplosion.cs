using UnityEngine;
using System.Collections;

public class ActivarExplosion : MonoBehaviour {

    public GameObject explosion;
    public GameObject gorro;
    public GameObject cuerpo;
    public float damageToGive;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BodyCollider")
        {
            explosion.SetActive(true);
            HealthManager.HerirJugador(damageToGive);
            Debug.Log("Explota");
            Destroy(gameObject.GetComponent<Collider2D>());
            Destroy(cuerpo.GetComponent<SpriteRenderer>());
            Destroy(gorro.GetComponent<SpriteRenderer>());
            Destroy(gameObject,0.8f);
        }

        }
}
