using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rato : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;

    private int life = 1;
 

    public BoxCollider2D colliderAtk;
    public BoxCollider2D colliderCheckAtk;

    private float originalMoveSpeed;
    public float moveSpeed;
    public bool ground = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);
        anim.SetBool("Andando", true);

        if (ground == false)
        {
            moveSpeed *= -1;
        }

        if (moveSpeed > 0 && !facingRight)
        {
            Flip();
        }

        else if (moveSpeed < 0 && facingRight)
        {
            Flip();
        }

        if(CheckAttack.checkAttack == true)
        {
            StartCoroutine(Attack());
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            life--;

            if (life < 1)
            {
                StopCoroutine("Attack");
                EnemyDead();
            }
        }
        
    }


    private void EnemyDead()
    {
        Debug.Log("ola");
        moveSpeed = 0;
        Destroy(gameObject);
        
    }


    IEnumerator Attack()
    {
        anim.SetBool("Andando", false);
        anim.SetBool("Damage", true);
        moveSpeed = 0;
        yield return new WaitForSeconds(0.85f);
        anim.SetBool("Damage", false);
        moveSpeed = originalMoveSpeed;
        CheckAttack.checkAttack = false;
    }
}
