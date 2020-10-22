using UnityEngine;
using System.Collections;

public class HurtPlayerOnContactEnemy2 : MonoBehaviour {

    public float damageToGive;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            HealthManager.HerirJugador(damageToGive);
        }
    }

}
