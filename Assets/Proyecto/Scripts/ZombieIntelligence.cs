﻿using UnityEngine;
using System.Collections;

public class ZombieIntelligence : MonoBehaviour {

    public Transform[] patrolpoints;
    int currentPoint;
    public float speed;
    public float timestill = 2f;
    public float sight = 3f;
    Animator anim;
    public float force;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("Patrol");
        anim.SetBool("Camina", true);
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, sight);
        if (hit.collider != null && hit.collider.tag == "BodyCollider")
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * force + (hit.collider.transform.position - transform.position) * force);
    }


    IEnumerator Patrol()
    {
        while (true)
        {

            if (transform.position.x == patrolpoints[currentPoint].position.x)
            {
                currentPoint++;
                anim.SetBool("Camina", false);
                anim.SetBool("Respira", true);
                yield return new WaitForSeconds(timestill);
                anim.SetBool("Camina", true);
                anim.SetBool("Respira", false);
            }


            if (currentPoint >= patrolpoints.Length)
            {
                currentPoint = 0;
            }

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(patrolpoints[currentPoint].position.x, transform.position.y), speed);

            if (transform.position.x > patrolpoints[currentPoint].position.x)
                transform.localScale = new Vector3(1.25f,1.25f, 1);
            else if (transform.position.x < patrolpoints[currentPoint].position.x)
                transform.localScale = new Vector3(-1.25f,1.25f,1);


            yield return null;


        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
            Destroy(this.gameObject, 0.1f);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.position + transform.localScale.x * Vector3.right * sight);

    }

}
