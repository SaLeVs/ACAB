using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogo : MonoBehaviour
{
    
    public GameObject gameOverUi;
    public GameObject gameWinUi;

    private GameObject player;
    

    public Jogo gameManager;
    

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
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
