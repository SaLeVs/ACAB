using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barreira : MonoBehaviour
{
    public Transform[] pos;
    public float velocidade = 2f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Botao.pisou == true || transform.position.y <= pos[1].position.y)
        {
            transform.Translate(Vector2.up * Time.deltaTime * velocidade);
        }
        if (Botao.pisou == false || transform.position.y >= pos[0].position.y)
        {
            transform.Translate(Vector2.down * Time.deltaTime * velocidade);
        }
        
    }
}
