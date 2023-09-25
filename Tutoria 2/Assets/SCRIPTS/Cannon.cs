using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject missileReference;
    [SerializeField]
    private GameObject firepoint;

    [SerializeField]
    private GameObject cannon;

    [SerializeField]
    int state = 0;

    Rigidbody2D rb;

    float cooldown = 0;

    public Animator anim;
    public SpriteRenderer sprite;

    public float vida;

    public Transform HealthBar;
    public GameObject HBO;

    private Vector3 HBS;
    private float hp;

    private bool isDead = false;

    public GameObject objetoNovo1; // Prefab do primeiro novo objeto.
    public GameObject objetoNovo2;

    public float offsetX = 1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        HBS = HealthBar.localScale;
        hp = HBS.x / vida;

        anim.SetBool("respira", true);
    }

    private void Update()
    {
        switch (state)
        {
            case 0:
                Idle();
                break;
            case 1:
                Aim();
            break;
            case 2:
                Follow();
            break;
        }

        if (isDead)
        {
            return;
        }
    }

    void Idle()
    {

    }

    void Aim()
    {
        Vector3 dif = target.transform.position+Vector3.up - transform.position;
        //cannon.transform.up = -dif;
        float value = Vector3.Dot(dif, cannon.transform.right);
        cannon.transform.Rotate(0, 0, value);
        if (cooldown <= 0)
        {
            Instantiate(missileReference, firepoint.transform.position, firepoint.transform.rotation) ;
            cooldown = 1;
        }
        cooldown -= Time.deltaTime;
    }
    void Follow()
    {
        if (!target) return;
        if (target.transform.position.x > transform.position.x)
        {
            rb.AddForce(Vector2.right * 100);
            anim.SetBool("respira", false);
            anim.SetBool("andandoesq", false);
            anim.SetBool("andandodir", true);
           
        }

        if (target.transform.position.x < transform.position.x)
        {
            
           rb.AddForce(Vector2.right * -100);
           anim.SetBool("respira", false);
           anim.SetBool("andandodir", false);
           anim.SetBool("andandoesq", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject;
            state = 1; 
        }

       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            state = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack" && !isDead)
        {

            vida--;
            UpdateHealthBar();
            Destroy(collision.gameObject);

            if (vida < 1)
            {
                isDead = true;
                EnemyDead();
            }
        }
    }

    void UpdateHealthBar()
    {
        HBS.x = hp * vida;
        HealthBar.localScale = HBS;

    }

    private void EnemyDead()
    {
        isDead = true;

        anim.SetBool("andandoesq", false);
        anim.SetBool("andandodir", false);
        anim.SetBool("respira", false);
        anim.SetBool("morreu", true);

        

        Destroy(gameObject, 2.5f);

        Instantiate(objetoNovo1, transform.position, Quaternion.identity);
        Vector3 newPosition = transform.position + new Vector3(offsetX, 0, 0);
        Instantiate(objetoNovo2, transform.position, Quaternion.identity);

    }
}
