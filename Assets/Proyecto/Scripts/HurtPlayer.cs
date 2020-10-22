using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HurtPlayer : MonoBehaviour {

    public float maxPlayerHealth;
    public static float playerHealth;

    private Text text;

    private LevelManagerGame levelManager;

    public bool isDead;

    void Start()
    {
        text = GetComponent<Text>();

        playerHealth = maxPlayerHealth;

        levelManager = FindObjectOfType<LevelManagerGame>();

        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {

            levelManager.RespawnPlayer();

            Debug.Log("Restablece");

            isDead = true;
        }

        text.text = "" + playerHealth;


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
