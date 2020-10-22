using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

    AudioSource SonidoMoneda;
    public int PointsToAdd;

    public AnimationClip animacion;

    void Awake() {
        SonidoMoneda = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "BodyCollider" || other.tag =="Player")
        {
            SonidoMoneda.Play();
            ScoreManager.AddPoints(PointsToAdd);
            GetComponent<Animator>().SetBool("MonedaRecogida", true);
        }
        DestructorLate();
    }

    private void DestructorLate() {
        Destroy(GetComponent<Collider2D>());
        Destroy(transform.parent.gameObject,(animacion.length));
    }


}