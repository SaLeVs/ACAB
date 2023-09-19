using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gelo : MonoBehaviour
{
    public BarraGelo barra;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jogo.tempoDeGelo = 5f;
            barra.AlterarVida(Jogo.tempoDeGelo);
            Destroy(gameObject);
        }
        
    }


}
