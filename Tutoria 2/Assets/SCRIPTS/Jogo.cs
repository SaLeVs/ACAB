using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogo : MonoBehaviour
{
    
    public GameObject gameOverUi;
    public GameObject gameWinUi;

    private GameObject player;
    

    public Jogo gameManager;

    public BarraGelo barra;
    public static float tempoDeGelo = 5f;

    
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        tempoDeGelo = 5;

        if (GameObject.FindGameObjectsWithTag("Gelo").Length > 0)
        {
            StartCoroutine(DiminuirValorCoroutine());
        }
        
        
    }

    void Update()
    {

       if (player == null)
       {
          gameManager.gameOver();
       }

       if (GameObject.FindGameObjectsWithTag("colet").Length == 0)
       {
            gameManager.gameWin();
       }

       if (tempoDeGelo <= 0)
       {
            gameManager.gameOver();
       }

      Debug.Log(tempoDeGelo);

    }
    private IEnumerator DiminuirValorCoroutine()
    {
        while (tempoDeGelo > 0)
        {
            tempoDeGelo--;
            barra.AlterarVida(tempoDeGelo);
            Debug.Log("Valor: " + tempoDeGelo);
            yield return new WaitForSeconds(1.0f);
        }
    }

    

    public void gameOver()
    {
        gameOverUi.SetActive(true);

    }

    public void gameWin()
    {
        gameWinUi.SetActive(true);

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        MyLoading1.LoadLevel("MainMenu");
    }

    public void level1()
    {
        MyLoading1.LoadLevel("lvl_1");
    }
    public void level2()
    {
        MyLoading1.LoadLevel("lvl_2");
    }

    public void quit()
    {
        Application.Quit();
    }
}
