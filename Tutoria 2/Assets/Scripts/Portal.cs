using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class Portal : MonoBehaviour
{
    public GameObject placa;
    [SerializeField] private string nomeProx;

    private bool playerInsideTrigger = false;

    void Start()
    {
        placa.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameObject.FindGameObjectsWithTag("Chave").Length == 0)
        {
            irProxFase();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            playerInsideTrigger = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerInsideTrigger && GameObject.FindGameObjectsWithTag("Chave").Length > 0)
        {
            placa.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            placa.SetActive(false);
        }
    }

    private void irProxFase()
    {
        SceneManager.LoadScene(this.nomeProx);
    }
}