using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{

    public float moveSpeed;
    public bool moveRight;


    //checkeo de paredes de enemigo
    public Transform wallCheck;
    public float wallCheckerRadius;
    public LayerMask whatIsWall;
    private bool chocandoEnPared;
    public float escala=1f;

    private bool notAtEdge;
    public Transform edgeCheck;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        chocandoEnPared = Physics2D.OverlapCircle(wallCheck.position, wallCheckerRadius, whatIsWall);

        notAtEdge= Physics2D.OverlapCircle(edgeCheck.position, wallCheckerRadius, whatIsWall);

        if (chocandoEnPared || !notAtEdge)
        {
            moveRight = !moveRight;
     
        }

        if (moveRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-escala, escala, 1f);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(escala, escala, 1f);
        }
    }


}