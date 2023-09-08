using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySho : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public Animator anima;
    private float timer;

    private GameObject player;

    public float speed;
    public bool ground = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool facingRight = true;

    int mortal = 2;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mortal = 2;

    }

    // Update is called once per frame
    void Update()
    {
       if(player == null)
        {
            return; 
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);

        if(ground == false)
        {
            speed *= -1;
        }

        if(speed > 0 && !facingRight) 
        {
            Flip();
        }

        else if(speed < 0 && facingRight)
        {
            Flip();
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        

        
        if (distance < 4)
        {
            timer += Time.deltaTime;


            if (timer > 1)
            {
                timer = 0;
                shoot();
            }

            speed = 0;
            anima.SetBool("ATIRA", true);
        }
        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;

        Scale.x *= -1;
        transform.localScale = Scale;
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            mortal--;

            if (mortal <= 0)
            {
                

                Destroy(gameObject);


                
            }

        }
    }
}
