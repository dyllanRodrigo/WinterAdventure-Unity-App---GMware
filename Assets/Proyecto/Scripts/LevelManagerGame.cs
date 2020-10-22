using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class LevelManagerGame : MonoBehaviour {

    private PlatformerCharacter2D controlDeJugador;
    private HealthManager healthManager;
    public GameObject[] elfo;
    
    public Transform player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public GameObject puntoRestauracion;

    public float respawnDelay;

	// Use this for initialization
	void Start () {
        controlDeJugador = FindObjectOfType<PlatformerCharacter2D>();
        healthManager = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void RespawnPlayer() {
        StartCoroutine("RespawnPlayerCoroutine");
    }

    //corutina se ejecuta con delay

    public IEnumerator RespawnPlayerCoroutine() {
            //craer un clone en escena de objeto deathparticle
            Instantiate(deathParticle, player.transform.position, player.transform.rotation);
            controlDeJugador.enabled = false;

        for (int i = 0; i < elfo.Length; i++)
        {
            elfo[i].GetComponent<Renderer>().enabled = false;
        }

        //delay de funcion IEnumerator
        yield return new WaitForSeconds(respawnDelay);
            //respawn
            player.transform.position = puntoRestauracion.transform.position;
            controlDeJugador.enabled = true;

        for (int i = 0; i < elfo.Length; i++)
        {
            elfo[i].GetComponent<Renderer>().enabled = true;
        }

        healthManager.FullHealth();
        healthManager.isDead = false;

        //objeto desaparece particulas
        Instantiate(respawnParticle, puntoRestauracion.transform.position, puntoRestauracion.transform.rotation);
        
    }
}
