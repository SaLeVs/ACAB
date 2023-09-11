using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Zumbi : MonoBehaviour
{
    public GameObject target;
    Rigidbody2D rdb;

      

    public Animator anim;

    int mortal = 2;
    bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
        mortal = 2;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 dif = target.transform.position - transform.position;
            rdb.AddForce(dif);

            if (dif.x > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (dif.x < 0 && isFacingRight)
            {
                Flip();
            }
        } 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            target = collision.gameObject;
            anim.SetBool("corre", true);
                

            
        }
        
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            mortal--;

            if (mortal <= 0)
            {
                rdb.gravityScale = 1f; 
                anim.SetBool("morri", true);
                Destroy(gameObject, 1f);
               
            }

        }
    }
}