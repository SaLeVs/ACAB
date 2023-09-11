using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ACAB : MonoBehaviour
{
    public Rigidbody2D rb;
    public float acabSpeed;
    private float direcao;
    public float jump;

    public Animator anim;


    private Vector3 ldireito;
    private Vector3 lesquerdo;

    public bool inGround;
    public Transform dttCao;
    public LayerMask isGround;

    public int pulosExtras = 1;

    public GameObject balaProjetil;
    public Transform arma;
    private bool tiro;
    public float forcaDoTiro;
    private bool flipX = false;
    public float velocidadeProjetil;

    // public Jogo gameManager;
    private bool IsDead;

    private int vida;
    private int vidaMax = 5;

    [SerializeField] Image Chave;

    [SerializeField] Image vidaOn;
    [SerializeField] Image vidaOff;

    [SerializeField] Image vidaOn2;
    [SerializeField] Image vidaOff2;

    [SerializeField] Image vidaOn3;
    [SerializeField] Image vidaOff3;

    [SerializeField] Image vidaOn4;
    [SerializeField] Image vidaOff4;

    private bool apertado = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        ldireito = transform.localScale;
        lesquerdo = transform.localScale;
        lesquerdo.x = lesquerdo.x * -1;

        vida = vidaMax;

        Chave.enabled = false;

    }





    void Update()
    {
        /*  if (this.gameObject == null)
          {

              gameManager.gameOver();
          } */

        if (Input.GetMouseButtonDown(1) && apertado == false)
        {
            StartCoroutine(Segurando());
            apertado = true;
        }

        if (Input.GetMouseButtonDown(1) && apertado == true)
        {
            StopCoroutine(Segurando());
            apertado = false;
        }

        
        anim.SetBool("ATIRANDO", false);
        tiro = Input.GetButtonDown("Fire1");

        Atirar();

        if (Input.GetAxis("Horizontal") != 0)
        {

            anim.SetBool("WALKANDO", true);
        }

        else

        {
            anim.SetBool("WALKANDO", false);
        }

        inGround = Physics2D.OverlapCircle(dttCao.position, 0.2f, isGround);

        if (Input.GetButtonDown("Jump") && inGround == true)
        {
            rb.velocity = Vector2.up * jump;
            anim.SetBool("JUMPADO", true);

        }

        if (Input.GetButtonDown("Jump") && inGround == false && pulosExtras > 0)
        {

            rb.velocity = Vector2.up * jump;
            pulosExtras--;
            anim.SetBool("JUMP2", true);

        }

        if (inGround && rb.velocity.y == 0)
        {
            pulosExtras = 1;
            anim.SetBool("JUMPADO", false);
            anim.SetBool("JUMP2", false);

        }



        direcao = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direcao * acabSpeed, rb.velocity.y);

        if (flipX == true && direcao > 0)
        {
            Flip();
            transform.localScale = ldireito;

        }

        if (flipX == false && direcao < 0)
        {
            Flip();
            transform.localScale = lesquerdo;

        }
        
    }
    private void Flip()
    {
        flipX = !flipX;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        forcaDoTiro *= -1;

    }

    private void Atirar()
    {
        if (tiro == true)
        {
            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
            Destroy(temp.gameObject, 1f);
            anim.SetBool("ATIRANDO", true);
        }
        
            

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("voat"))
        {

            Dano();
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.CompareTag("colet"))
        {

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Dano();

        }

        if (collision.gameObject.CompareTag("Damage01"))
        {
            Dano();
        }

        if (collision.gameObject.CompareTag("Chave"))
        {

            Destroy(collision.gameObject);
            Chave.enabled = true;
            Debug.Log("CHEGUEI");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Dano();
        }

    }

    IEnumerator Blink()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1, 1, 1);
    }
    IEnumerator Segurando()
    {
        anim.SetBool("seg", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("seg", false);
    }

    private void Dano()
    {
        
        vida -= 1;

        StartCoroutine(Blink());
        
        if(vida == 4)
        {
            vidaOn4.enabled = true;
            vidaOff4.enabled = false;
        }
        else
        {
            vidaOn4.enabled = false;
            vidaOff4.enabled = true;
        }

        if (vida == 3)
        {
            vidaOn4.enabled = true;
            vidaOff4.enabled = false;

            vidaOn3.enabled = true;
            vidaOff3.enabled = false;
        }
        else
        {
            vidaOn3.enabled = false;
            vidaOff3.enabled = true;
        }

        if (vida == 2)
        {
            vidaOn4.enabled = true;
            vidaOff4.enabled = false;
            vidaOn3.enabled = true;
            vidaOff3.enabled = false;
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;

        }
        else
        {
            vidaOn2.enabled = false;
            vidaOff2.enabled = true;
        }

        if (vida == 1)
        {
            vidaOn4.enabled = true;
            vidaOff4.enabled = false;
            vidaOn3.enabled = true;
            vidaOff3.enabled = false;
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;
            vidaOn.enabled = true;
            vidaOff.enabled = false;

        }
        else
        {
            vidaOn.enabled = false;
            vidaOff.enabled = true;
        }

        if (vida <= 0)

        {
            anim.SetBool("MORREU", true);
            Destroy(gameObject, 1.5f);
            
        }

        
    }


}
