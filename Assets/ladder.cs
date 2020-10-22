using UnityEngine;
using System.Collections;

public class ladder : MonoBehaviour
{

    public float speed = 6;
    public GameObject jugador;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            jugador.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            jugador.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        }
        else
        {

            jugador.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);

        }



    }
}
