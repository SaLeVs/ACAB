using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COP_BOSS : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;

    public EdgeCollider2D colliderAtk;
    public BoxCollider2D colliderCheckAtk;

    public BoxCollider2D colliderSpr;
    public CircleCollider2D colliderCheckSpr;

    public float vida; 

    public Transform HealthBar;
    public GameObject HBO;

    private Vector3 HBS;
    private float hp;

   

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        HBS = HealthBar.localScale;
        hp = HBS.x / vida;

        
}

    void UpdateHealthBar()
    {
        HBS.x = hp * vida;
        HealthBar.localScale = HBS;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {

            vida--;
            UpdateHealthBar();
            Destroy(collision.gameObject);

            if (vida < 1)
            {
                EnemyDead();
            }
        }
    }


    


    private void EnemyDead()
    {
        anim.SetBool("respirando", false);
        anim.SetBool("atacando", false);
        anim.SetBool("spray", false);
        anim.SetBool("morreu", true);
        Destroy(gameObject, 3f);


    }


    // Update is called once per frame
    void Update()
    {
        anim.SetBool("respirando", true);

        if (CheckAttack.checkAttack == true)
        {
            StartCoroutine(Attack());
            StopCoroutine(Spray());
        }

        if (CheckSpray.checkSpray == true && vida <= 7)
        {
            StopCoroutine(Attack());
            StartCoroutine(Spray());
        }

    }

    IEnumerator Attack()
    {
        anim.SetBool("respirando", false);
        anim.SetBool("atacando", true);
        yield return new WaitForSeconds(0.85f);
        CheckAttack.checkAttack = false;
        anim.SetBool("atacando", false);
    }

    IEnumerator Spray()
    {
        anim.SetBool("respirando", false);
        anim.SetBool("atacando", false);
        anim.SetBool("spray", true);
        yield return new WaitForSeconds(0.85f);
        CheckSpray.checkSpray = false;
        anim.SetBool("spray", false);
    }
}
 