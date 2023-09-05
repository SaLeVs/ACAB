using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class vamos : MonoBehaviour
{
    [SerializeField]
    private string nomeProx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            irProxFase();
        }
    }

    private void irProxFase()
    {
        SceneManager.LoadScene(this.nomeProx);
    }

}
