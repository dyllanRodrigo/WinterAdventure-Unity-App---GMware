using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public float maxPlayerHealth;
    //en caso de detectar unico trigger tipo de dato INT en playerhealth

    public static float playerHealth;

    //private Text text;
    public Slider healthbar;

    private LevelManagerGame levelManager;

    public bool isDead;


    //vidas

    private LifeManager lifeSystem;


    void Start()
    {
        //text = GetComponent<Text>();
        healthbar = GetComponent<Slider>();
        playerHealth = maxPlayerHealth;

        levelManager = FindObjectOfType<LevelManagerGame>();

        isDead = false;

        lifeSystem = FindObjectOfType<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;

            levelManager.RespawnPlayer();
            lifeSystem.TakeLife();
            Debug.Log("Restablece");
           
            isDead = true; 
        }

        // text.text = "" + playerHealth;
        healthbar.value = playerHealth;

    }


    public static void HerirJugador(float damageToGive)
    {

        playerHealth -= damageToGive;
    }

    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
