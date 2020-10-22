using UnityEngine;
using System.Collections;

public class DiamondPickup : MonoBehaviour {

    AudioSource Sonido;
    public int PointsToAdd;

    public AnimationClip animacion;

    void Awake()
    {
        Sonido = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "BodyCollider" || other.tag =="Player")
        {
            Sonido.Play();
            ScoreManager.AddPoints(PointsToAdd);
            GetComponent<Animator>().SetBool("GemaDesaparece", true);
        }
        DestructorLate();
    }

    private void DestructorLate()
    {
        Destroy(GetComponent<Collider2D>());
        Destroy(transform.parent.gameObject, (Sonido.clip.length));
    }


}