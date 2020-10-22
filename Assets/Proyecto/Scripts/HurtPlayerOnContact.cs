﻿using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {


    public float damageToGive;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}


    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player")
        {
            HealthManager.HerirJugador(damageToGive);
        }
    }


    void OnColliderEnter2D(Collider2D other) {
        if (other.tag == "BodyCollider")
        {
            HealthManager.HerirJugador(damageToGive);
        }
    }
}